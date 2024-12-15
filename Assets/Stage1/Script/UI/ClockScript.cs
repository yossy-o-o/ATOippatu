using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

// タイマー、成功処理
public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    DamageJudgment damageJudgment;

    public float clockTime = 5;
    void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        ClockSysytem();
    }

    //タイマーの処理
    public void ClockSysytem()
    {
        clockTime -= Time.deltaTime;

        if(clockTime < 0)
        {
            clockTime = 0;

            GameManager.instance.HandleMiniGameResult(true); //成功を処理

            damageJudgment.DisableEnemy(); //敵を削除

        }

        clockText.text = clockTime.ToString("F1");
    }


}
