using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��l�̃J�����̃V�X�e���A�}�E�X�ɂ���ăJ�����𓮂���
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
     */

    public Camera playerCamera; //�J����

    private float mouseSpeed = 2.0f; //�J�������x

    private float mouseX; //�}�E�X���WX

    private float mouseY; //�}�E�X���WY

    private float carrentXAngle; //X�̗ݐϊp�x�ێ�

    private float carrentYAngle; //Y�̗ݐϊp�x�ێ�
    

   
    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        CameraAngle();
    }

    //�J�����̏���
    void CameraAngle()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Debug.Log("Current X Angle: " + carrentXAngle);

        carrentXAngle += mouseY * mouseSpeed; //��]���Ă�����X�̊p�x��ێ�
        carrentYAngle += mouseX * mouseSpeed; //��]���Ă�����Y�̊p�x��ێ�


        playerCamera.transform.localRotation = Quaternion.Euler(carrentXAngle, 0, 0); //X���̉�]


        transform.localRotation = Quaternion.Euler(0, carrentYAngle, 0); //Y����]


        carrentXAngle = Mathf.Clamp(carrentXAngle, -90f, 90f);
    }

}
