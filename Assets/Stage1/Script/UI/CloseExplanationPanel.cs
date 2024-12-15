using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//説明パネルをEnterで非表示にする
public class CloseExplanationPanel : MonoBehaviour
{
    [SerializeField] GameObject explanationPanel;
    void Update()
    {
        ClosePanel();
    }

    //Enterで非表示
    private void ClosePanel()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            explanationPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
