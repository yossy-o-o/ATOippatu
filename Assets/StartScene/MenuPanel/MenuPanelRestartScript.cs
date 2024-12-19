using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//メニューパネルのリスタート処理
public class MenuPanelRestartScript : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    private float DelayTime = 1.0f;
    public void OnClickMenuPanelRestartButton()
    {
        StartCoroutine(DelayLoad());

        settingPanel.SetActive(false);

        GameManager.instance.RestartGame();
    }

    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(DelayTime);
    }
}
