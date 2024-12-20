using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//return�{�^������
public class RetrunHome : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;

    [SerializeField] AudioSource creditAudioSource;
    public void OnClickReturnButton()
    {
        creditAudioSource.Play();
        creditPanel.SetActive(false);
    }
}
