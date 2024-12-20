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

    [SerializeField] List<GameObject> enemy = new List<GameObject>();

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

            PlayerDestroy();
            //Debug.Log("ê¨å˜");
            GameManager.instance.HandleMiniGameResult(true);

        }
        
        clockText.text = limitTime.ToString("F1");
    }

    private void PlayerDestroy()
    {
        foreach(GameObject Enemys in enemy)
        {
            Destroy(Enemys);
        }
    }

}
