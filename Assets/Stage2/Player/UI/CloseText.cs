using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Stage2�ŁA�ŏ��ɏo�Ă���UI���폜
public class CloseText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI youText; //�\������e�L�X�g

    [SerializeField] GameObject image;

    [SerializeField] Transform charcter; //�\������L�����N�^�[

    [SerializeField] Vector3 offSet = new Vector3(0, 2, 0);�@//�\���ʒu

    [SerializeField] float closeTime = 3.0f; //�f�B���C����
    void Start()
    {
        StartCoroutine(TextClose());
    }

    //�e�L�X�g�������܂Ŏ��Ԃ�������
    private IEnumerator TextClose()
    {
        youText.transform.position = charcter.transform.position + offSet;

        yield return new WaitForSeconds(closeTime);
    }
}
