using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESC�{�^���Ń��j���[�p�l���\��
public class MenuPanelScript : MonoBehaviour
{
    [SerializeField] GameObject escPanel;

    private bool isCheckEsc = false;

    private void Update()
    {
        ShowMenuPanel();
    }

    private void ShowMenuPanel()
    {
        // Escape�L�[�������ꂽ�Ƃ��̏���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCheckEsc = !isCheckEsc; // �t���O�𔽓]

            // �p�l���̕\��/��\����؂�ւ�
            escPanel.SetActive(isCheckEsc);
        }
    }
}
