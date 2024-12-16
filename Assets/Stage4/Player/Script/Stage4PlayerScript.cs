using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage4��Player�̓�������
public class RigidBodyVelocity : MonoBehaviour
{
    public float playerSpeed = 3f; //�v���C���[�̃X�s�[�h
    public float rotationSpeed = 5f; // ��]���x�𒲐�����ϐ�
    Rigidbody rb;
    public Transform cameraTransform; // �J������Transform��Inspector�Ŋ��蓖��

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
        // �J�����̕�������Ɉړ��������v�Z
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Y�����i�㉺�����j�͖���
        forward.y = 0;
        right.y = 0;

        // ���K�����Ď΂߈ړ����̑��x�����ɕۂ�
        forward.Normalize();
        right.Normalize();

        // ���͂ɉ������ړ�����
        Vector3 moveDirection = forward * moveZ + right * moveX;

        // Rigidbody�̑��x��ݒ�
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // �ړ�����������ꍇ������]����
        if (moveDirection != Vector3.zero)
        {
            RotateCharacter(moveDirection);
        }
    }

    private void Move()
    {
        // ���͎擾
        moveX = Input.GetAxis("Horizontal") * playerSpeed; // D / A �L�[
        moveZ = Input.GetAxis("Vertical") * playerSpeed;   // W / S �L�[
    }

    private void RotateCharacter(Vector3 moveDirection)
    {
        // ���݂̉�]
        Quaternion currentRotation = transform.rotation;

        // �ړ������Ɋ�Â��ڕW�̉�]
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // ���݂̉�]����ڕW�̉�]�֕��
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
