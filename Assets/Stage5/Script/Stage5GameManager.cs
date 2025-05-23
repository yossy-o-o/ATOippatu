using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//����������s��
public class Stage5GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float timer = 15.0f;

    [SerializeField] BulletScript bulletScript;

    [SerializeField] GameObject bullet;

    [SerializeField] GameObject bullet2;

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
            Destroy(gameObject);

            Destroy(bullet);

            Destroy(bullet2);

            timer = 0;

            isSuccess = true;

            bulletScript.isShooting = false;

            GameManager.instance.HandleMiniGameResult(true);
        }

        timerText.text = timer.ToString("F1");
    }
}
