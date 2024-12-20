using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCボタンでメニューパネル表示
public class MenuPanelScript : MonoBehaviour
{
    [SerializeField] GameObject escPanel;

    private bool isCheckEsc = false;

    private void Update()
    {
        ShowMenuPanel();
    }

    private void ShowMenuPanel()
    {
        // Escapeキーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCheckEsc = !isCheckEsc; // フラグを反転

            // パネルの表示/非表示を切り替え
            escPanel.SetActive(isCheckEsc);
        }
    }
}
