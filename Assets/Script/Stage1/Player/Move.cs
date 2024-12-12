using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Playerの移動を担当
public class Move : MonoBehaviour
{
    /*やること
     * 
     * GetAxisでHorizontal,Verticalを取得する
     * 速度を持たせる
     * 
     */

    protected float playerSpeed = 5.0f; //playerのスピード

    protected Rigidbody rb;

    

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();
    }

    protected virtual void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        //rigidbodyで移動
        if (moveDirection.magnitude > 0)
        {
            rb.MovePosition(transform.position + moveDirection * playerSpeed * Time.deltaTime);
        }

    }

}
