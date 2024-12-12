using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Player�̈ړ���S��
public class Move : MonoBehaviour
{
    /*��邱��
     * 
     * GetAxis��Horizontal,Vertical���擾����
     * ���x����������
     * 
     */

    protected float playerSpeed = 5.0f; //player�̃X�s�[�h

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

        //rigidbody�ňړ�
        if (moveDirection.magnitude > 0)
        {
            rb.MovePosition(transform.position + moveDirection * playerSpeed * Time.deltaTime);
        }

    }

}
