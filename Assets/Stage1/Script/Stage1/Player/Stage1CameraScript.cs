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

    private UnityEngine.Vector3 playerPos;//�v���C���[�̈ʒu�̕ϐ�

    private float speed = 100f; //�J�����̃X�s�[�h���擾

    private float mouseInputX;

    private float mouseInputY;

    void Start()
    {
        playerPos = player.transform.position;

        // �J�����̌������v���C���[�̌����ɍ��킹��
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        CameraSystem();
    }

    private void CameraSystem()
    {
        //playerPos = player.transform.position;�Ŏ擾�����ʒu��
        //transform.position += player.transform.position - playerPos;�ň����āA���̍�����playerPos = player.transform.position;�����ł܂��擾���Ă���
        //�J�����ʒu���v���C���[�̈ʒu�ɍ��킹��
        //�J�����̈ړ� = �ړ�����W-�ړ��O���W�@
        transform.position += player.transform.position - playerPos;
        //�ړ��O���W = �ړ�����W
        playerPos = player.transform.position;

        //�}�E�X��X����Y���̓��͂��擾
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = -Input.GetAxis("Mouse Y");

        //�J��������]������
        transform.RotateAround(playerPos, UnityEngine.Vector3.up, mouseInputX * Time.deltaTime * speed);
        transform.RotateAround(playerPos, transform.right, mouseInputY * Time.deltaTime * speed);
    }

}

