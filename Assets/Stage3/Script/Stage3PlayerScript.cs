using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerの動き
public class Stage3PlayerScript : MonoBehaviour
{
    public float playerSpeed = 10.0f; //プレイヤーの移動速度

    private float gravityAcceleration = -0.01f; //重力加速度

    private float moveX; //Horizontal

    private float moveZ; //Vertical

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 movePlayer = new Vector3(moveX, rb.velocity.y, moveZ) * playerSpeed;

        Vector3 carrentVelocity = rb.velocity;

        movePlayer.y = carrentVelocity.y + gravityAcceleration + Time.deltaTime;

        rb.velocity = movePlayer;
    }
}
