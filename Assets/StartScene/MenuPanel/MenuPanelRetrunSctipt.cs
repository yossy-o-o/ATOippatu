using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//メニューパネルのスタートシーンに移行する処理
public class MenuPanelRetrunSctipt : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    [SerializeField] AudioSource retrunAudio;

    private void Start()
    {
        
    }
    public void OnclickRetrunButton()
    {
        retrunAudio.Play();

        settingPanel.SetActive(false);

        SceneManager.LoadScene("StartScene");
    }
}
