using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

//êßå¿éûä‘Ç≈ÉNÉäÉAèàóù
public class Stage2Success : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clockText;

    [SerializeField] private float limitTime = 20.0f;

    [SerializeField] GameObject enemy;

    private bool isSuccess = false;
    void Start()
    {
        
    }

    void Update()
    {
        Clock();
    }

    private void Clock()
    {
        if (isSuccess) return;

        limitTime -= Time.deltaTime;

        if(limitTime <= 0)
        {
            limitTime = 0;
            isSuccess = true;

            Destroy(enemy);
            //Debug.Log("ê¨å˜");
            GameManager.instance.HandleMiniGameResult(true);

        }
        
        clockText.text = limitTime.ToString("F1");
    }

    

}
