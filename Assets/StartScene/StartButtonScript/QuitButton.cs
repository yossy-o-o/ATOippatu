using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームを終了する
public class QuitButton : MonoBehaviour
{
    public void OnclickQuitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //Editor上で終了

        #else
            Application.Quit();//ゲームプレイ終了

        #endif
    }
}
