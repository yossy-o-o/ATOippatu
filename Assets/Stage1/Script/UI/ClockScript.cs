using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    [SerializeField] List<GameObject> enemy;
    public float clockTime = 5;

    private bool isSuccess = false; // ���������̃t���O

    void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ClockSysytem();
    }

    // �^�C�}�[�̏���
    public void ClockSysytem()
    {
        if (isSuccess) return; // ������ԂȂ珈�����X�L�b�v

        clockTime -= Time.deltaTime;

        if (clockTime <= 0)
        {
            clockTime = 0;

            isSuccess = true; // ������Ԃ��Z�b�g

            GameManager.instance.HandleMiniGameResult(true); // ������ʒm

            FalseEnemy(); // �G�𖳌���
        }

        clockText.text = clockTime.ToString("F1");
    }

    private void FalseEnemy()
    {
        foreach (GameObject enemy in enemy)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }
    }
}
