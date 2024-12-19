using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クレジットボタン
public class CreditButton : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;

    [SerializeField] AudioSource creditAudioSource;
    public void OnclickCreditButton()
    {
        creditAudioSource.Play();
        creditPanel.SetActive(true);
    }
}
