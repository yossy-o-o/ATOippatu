using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[�����I������
public class QuitButton : MonoBehaviour
{
    public void OnclickQuitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //Editor��ŏI��

        #else
            Application.Quit();//�Q�[���v���C�I��

        #endif
    }
}
