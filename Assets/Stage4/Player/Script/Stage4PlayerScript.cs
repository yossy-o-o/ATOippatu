using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4PlayerMove: MonoBehaviour
{
    public float playerSpeed = 3f; // プレイヤーの移動速度
    public float rotationSpeed = 5f; // プレイヤーの回転速度

    private Rigidbody rb;

    private float moveX;
    private float moveZ;

    private bool isFootStep = false;

    private float footStepSoundTime = 0.7f; 

    AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetInput(); // 入力を取得
    }

    private void FixedUpdate()
    {
        MovePlayer(); // プレイヤーを移動
    }

    private void GetInput()
    {
        // 入力取得（W/A/S/D または矢印キー）
        moveX = Input.GetAxis("Horizontal"); // 横方向の入力（A/D）
        moveZ = Input.GetAxis("Vertical");   // 縦方向の入力（W/S）
    }

    private void MovePlayer()
    {
        
        
        // 入力に基づいた移動方向を計算
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

        // Rigidbodyの速度を設定（速度を正規化して一定の移動速度を保つ）
        rb.velocity = moveDirection.normalized * playerSpeed + new Vector3(0, rb.velocity.y, 0);

        // 入力がある場合にのみ回転
        if (moveDirection.sqrMagnitude > 0.01f)
        {

            RotatePlayer(moveDirection);
        }

        if (moveDirection.sqrMagnitude > 0.01f && !isFootStep)
        {
            StartCoroutine(PlayFootStepSound());
        }
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        // プレイヤーが向くべき方向を計算
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // スムーズに回転する
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator PlayFootStepSound()
    {
        if (!isFootStep)
        {
            isFootStep = true;

            audio.Play();

            yield return new WaitForSeconds(footStepSoundTime);

            isFootStep = false;
        }
    }
}
