using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���U���g�p�l���̃��X�^�[�g�{�^������
public class RestartButton : MonoBehaviour
{
    public void OnClickRestart()
    {
        GameManager.instance.RestartGame(); //GameManager����A���X�^�[�g���Ăяo��
    }
}
