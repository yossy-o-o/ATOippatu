using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//result�p�l���̃X�^�[�g�V�[���ɖ߂�p�l��
public class ReturnButtonScript : MonoBehaviour
{
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
