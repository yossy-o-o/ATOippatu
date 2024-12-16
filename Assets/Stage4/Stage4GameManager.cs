using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Stage4のゲームマネージャーと成功判定
public class Stage4GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] private float timer = 20.0f;

    [SerializeField] List<GameObject> enemy = new List<GameObject>();

    private bool isSuccess = false;
    void Start()
    {
        
    }

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

            Debug.Log("成功");

            EnemySetFalse();

            GameManager.instance.HandleMiniGameResult(true); 
        }

        timeText.text = timer.ToString("F1");
    }

    private void EnemySetFalse()
    {
        foreach(GameObject Enemy in enemy)
        {
            Enemy.SetActive(false);
        }
    }
}
