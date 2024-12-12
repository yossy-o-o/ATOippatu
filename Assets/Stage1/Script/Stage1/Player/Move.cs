using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb; // Rigidbody �� rb ��

    public float speed = 5f; // �v���C���[�̈ړ����x

    private float inputHorizontal; // ������
    private float inputVertical;   // �c����

    private Vector3 moveDirection; // �ړ�����

    private Vector3 cameraForward; // �J�����̑O����

    private Vector3 cameraRight;   // �J�����̉E����

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
        // �ړ�����
        PlayerMove();
    }

    private void CameraDistanceCalculation()
    {
        // �L�[�{�[�h���͂��擾
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // �J�����̑O�����ƉE�������擾�iY���͐����̂ݍl���j
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        // ���͂Ɋ�Â��Ĉړ��������v�Z�i�J������j
        moveDirection = cameraForward * inputVertical + cameraRight * inputHorizontal;
    }

    private void PlayerMove()
    {
        // Rigidbody �Ɉړ����x��K�p�i�ړ����� �~ ���x�j
        rb.velocity = moveDirection * speed + new Vector3(0, rb.velocity.y, 0);
    }
}
