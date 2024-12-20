using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��l�̃J�����̃V�X�e���A�}�E�X�ɂ���ăJ�����𓮂����A
public class Stage1CameraScript : MonoBehaviour
{
    /*
     * �����������J�������擾����
     * �J�����̍��W���擾����
     * �}�E�X���擾����
     * �}�E�X�̑��x���擾����
     * �}�E�X��X�̉�]�ݐς��擾
     * �}�E�X��Y�̉�]�ݐς��擾
     * �擾����X,Y�̗ݐϊp�x���J���������
     * 
     * 
     */

    [SerializeField] GameObject player;

    private Vector3 playerPosition;//���ݒn�擾

    private float speed = 200f; //�J�����̃X�s�[�h���擾

    private float mouseInputX;

    private float mouseInputY;

    void Start()
    {
        playerPosition = player.transform.position; //player�̈ʒu���擾

        // �J�����̌������v���C���[�̌����ɍ��킹��
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        CameraSystem();
    }

    private void CameraSystem()
    {�@
        transform.position += player.transform.position - playerPosition;
        playerPosition = player.transform.position;

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = -Input.GetAxis("Mouse Y");

        //�J��������]������
        transform.RotateAround(playerPosition, Vector3.up, mouseInputX * Time.deltaTime * speed);
        transform.RotateAround(playerPosition, transform.right, mouseInputY * Time.deltaTime * speed);
    }

}

