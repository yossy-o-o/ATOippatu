using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Stage2で、最初に出てくるUIを削除
public class CloseText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI youText; //表示するテキスト

    [SerializeField] GameObject image;

    [SerializeField] Transform charcter; //表示するキャラクター

    [SerializeField] Vector3 offSet = new Vector3(0, 2, 0);　//表示位置

    [SerializeField] float closeTime = 3.0f; //ディレイ時間
    void Start()
    {
        StartCoroutine(TextClose());
    }

    //テキストを消すまで時間をかける
    private IEnumerator TextClose()
    {
        youText.transform.position = charcter.transform.position + offSet;

        yield return new WaitForSeconds(closeTime);
    }
}
