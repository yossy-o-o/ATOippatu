using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//ê¨å˜îªíËÇçsÇ§
public class Stage5GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float timer = 15.0f;

    [SerializeField] BulletScript bulletScript;

    bool isSuccess = false;

    void Update()
    {
        SuccessTimer();
    }

    private void SuccessTimer()
    {
        if (isSuccess) return;

        timer -= Time.deltaTime;
 

        if(timer <= 0)
        {
            timer = 0;

            isSuccess = true;

            bulletScript.isShooting = false;

            GameManager.instance.HandleMiniGameResult(true);
        }

        timerText.text = timer.ToString("F1");
    }
}
