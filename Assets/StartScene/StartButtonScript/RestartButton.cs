using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//リザルトパネルのリスタートボタン処理
public class RestartButton : MonoBehaviour
{
    public void OnClickRestart()
    {
        GameManager.instance.RestartGame(); //GameManagerから、リスタートを呼び出し
    }
}
