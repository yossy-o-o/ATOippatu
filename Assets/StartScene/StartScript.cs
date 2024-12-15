using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//スタートシーンのパネルを閉じて、ゲームシーンに入る
public class StartScript : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    void Start()
    {
        
    }

    void Update()
    {
        GameStart();
    }

    private void GameStart()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            startPanel.SetActive(false);
            SceneManager.LoadScene("Stage1Scene");
        }
    }
}
