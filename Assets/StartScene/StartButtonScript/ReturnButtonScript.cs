using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//result�p�l���̃X�^�[�g�V�[���ɖ߂�p�l��
public class ReturnButtonScript : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;

    [SerializeField] GameObject failPanel;

    [SerializeField] GameObject successPanel;
    public void OnClickReturnButton()
    {
        resultPanel.SetActive(false);

        failPanel.SetActive(false);

        successPanel.SetActive(false);

        SceneManager.LoadScene("StartScene");
    }
}
