using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//最初にでる"YOU"を削除する処理
public class YOUUiScript : MonoBehaviour
{
    [SerializeField] GameObject youText;

    [SerializeField] float closeTime = 1.0f;

    private void Update()
    {
        StartCoroutine(CloseYouUi());
    }

    private IEnumerator CloseYouUi()
    {
        yield return new WaitForSeconds(closeTime);

        youText.SetActive(false);
    }
}
