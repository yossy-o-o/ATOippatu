using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���j���[�p�l���̃X�^�[�g�V�[���Ɉڍs���鏈��
public class MenuPanelRetrunSctipt : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    public void OnclickRetrunButton()
    {
        settingPanel.SetActive(false);

        SceneManager.LoadScene("StartScene");
    }
}
