using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage4のPlayerの動く処理
public class RigidBodyVelocity : MonoBehaviour
{
    public float playerSpeed = 3f; //プレイヤーのスピード
    public float rotationSpeed = 5f; // 回転速度を調整する変数
    Rigidbody rb;
    public Transform cameraTransform; // カメラのTransformをInspectorで割り当て

    float moveX;
    float moveZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        CameraSystem();
    }

    private void CameraSystem()
    {
        // カメラの方向を基準に移動方向を計算
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Y方向（上下方向）は無視
        forward.y = 0;
        right.y = 0;

        // 正規化して斜め移動時の速度を一定に保つ
        forward.Normalize();
        right.Normalize();

        // 入力に応じた移動方向
        Vector3 moveDirection = forward * moveZ + right * moveX;

        // Rigidbodyの速度を設定
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // 移動方向がある場合だけ回転する
        if (moveDirection != Vector3.zero)
        {
            RotateCharacter(moveDirection);
        }
    }

    private void Move()
    {
        // 入力取得
        moveX = Input.GetAxis("Horizontal") * playerSpeed; // D / A キー
        moveZ = Input.GetAxis("Vertical") * playerSpeed;   // W / S キー
    }

    private void RotateCharacter(Vector3 moveDirection)
    {
        // 現在の回転
        Quaternion currentRotation = transform.rotation;

        // 移動方向に基づく目標の回転
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // 現在の回転から目標の回転へ補間
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
