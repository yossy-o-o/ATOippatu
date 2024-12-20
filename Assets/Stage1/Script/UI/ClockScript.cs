using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    [SerializeField] List<GameObject> enemy;
    public float clockTime = 5;

    private bool isSuccess = false; // 成功処理のフラグ

    void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ClockSysytem();
    }

    // タイマーの処理
    public void ClockSysytem()
    {
        if (isSuccess) return; // 成功状態なら処理をスキップ

        clockTime -= Time.deltaTime;

        if (clockTime <= 0)
        {
            clockTime = 0;

            isSuccess = true; // 成功状態をセット

            GameManager.instance.HandleMiniGameResult(true); // 成功を通知

            FalseEnemy(); // 敵を無効化
        }

        clockText.text = clockTime.ToString("F1");
    }

    private void FalseEnemy()
    {
        foreach (GameObject enemy in enemy)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }
    }
}
