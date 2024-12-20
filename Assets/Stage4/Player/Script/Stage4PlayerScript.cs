using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4PlayerMove: MonoBehaviour
{
    public float playerSpeed = 3f; // �v���C���[�̈ړ����x
    public float rotationSpeed = 5f; // �v���C���[�̉�]���x

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
        GetInput(); // ���͂��擾
    }

    private void FixedUpdate()
    {
        MovePlayer(); // �v���C���[���ړ�
    }

    private void GetInput()
    {
        // ���͎擾�iW/A/S/D �܂��͖��L�[�j
        moveX = Input.GetAxis("Horizontal"); // �������̓��́iA/D�j
        moveZ = Input.GetAxis("Vertical");   // �c�����̓��́iW/S�j
    }

    private void MovePlayer()
    {
        
        
        // ���͂Ɋ�Â����ړ��������v�Z
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

        // Rigidbody�̑��x��ݒ�i���x�𐳋K�����Ĉ��̈ړ����x��ۂj
        rb.velocity = moveDirection.normalized * playerSpeed + new Vector3(0, rb.velocity.y, 0);

        // ���͂�����ꍇ�ɂ̂݉�]
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
        // �v���C���[�������ׂ��������v�Z
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        // �X���[�Y�ɉ�]����
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
