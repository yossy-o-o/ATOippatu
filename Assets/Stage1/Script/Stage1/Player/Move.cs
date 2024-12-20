using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb; // Rigidbody を rb に

    public float speed = 5f; // プレイヤーの移動速度

    private float inputHorizontal; // 横方向
    private float inputVertical;   // 縦方向

    private Vector3 moveDirection; // 移動方向

    private Vector3 cameraForward; // カメラの前方向

    private Vector3 cameraRight;   // カメラの右方向

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CameraDistanceCalculation();
    }

    void FixedUpdate()
    {
        // 移動処理
        PlayerMove();
    }

    private void CameraDistanceCalculation()
    {
        // キーボード入力を取得
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // カメラの前方向と右方向を取得（Y軸は水平のみ考慮）
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        // 入力に基づいて移動方向を計算（カメラ基準）
        moveDirection = cameraForward * inputVertical + cameraRight * inputHorizontal;
    }

    private void PlayerMove()
    {
        // Rigidbody に移動速度を適用（移動方向 × 速度）
        rb.velocity = moveDirection * speed + new Vector3(0, rb.velocity.y, 0);
    }
}
