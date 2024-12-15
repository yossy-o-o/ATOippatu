using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

// �^�C�}�[�A��������
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

    //�^�C�}�[�̏���
    public void ClockSysytem()
    {
        clockTime -= Time.deltaTime;

        if(clockTime < 0)
        {
            clockTime = 0;

            GameManager.instance.HandleMiniGameResult(true); //����������

            damageJudgment.DisableEnemy(); //�G���폜

        }

        clockText.text = clockTime.ToString("F1");
    }


}
