using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����p�l����Enter�Ŕ�\���ɂ���
public class CloseExplanationPanel : MonoBehaviour
{
    [SerializeField] GameObject explanationPanel;
    void Update()
    {
        ClosePanel();
    }

    //Enter�Ŕ�\��
    private void ClosePanel()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            explanationPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
