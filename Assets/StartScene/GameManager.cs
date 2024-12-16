using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�~�j�Q�[�������A���s�������Ǘ�����X�N���v�g.
public class GameManager : MonoBehaviour
{
    /*��邱��
     * 
     * �S���̃~�j�Q�[���ɋ��ʂ���̂ŁA�V���O���g����
     * ���ꂼ��̃V�[�����擾����
     * ���C�t(�c�@)�̌�
     * ��莞�Ԑ����c������Ő������s������s���Ă��āA�ꌳ�Ǘ��ł���̂Ń^�C�}�[������
     * ���ʂ��p�l����\���A���������玟�̃X�e�[�W�A���s�����烉�C�t�����炵�Ď��̃X�e�[�W�����[�h
     * ���ꂼ��̃V�[���ŁA�������s�̃t���O���擾���āAGameManger�ɒʒm
     * ���񐔌J��Ԃ��Đ����c���Ă�����N���A�A���s
     * ���Ԃ���������G���h���X����
     * 
     */

    public static GameManager instance; //�V���O���g����.

    private int playerLife = 5; //�v���C���̃��C�t.

    [SerializeField] List<Image> images = new List<Image>();//���X�g��image���擾.

    [SerializeField] GameObject succesPanel; //�����p�l��.

    [SerializeField] GameObject failPanel; //���s�p�l��.

    [SerializeField] float PanelDelayTime = 3f;


    void Awake()
    {
        //�C���X�^���X��
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //���C�t���S���Ȃ��Ȃ�AGameOver�̏������s��.
    public void HandleMiniGameResult(bool success)
    {

        if (success)
        {
            Debug.Log("�����p�l����\��");
            succesPanel.SetActive(true);//�����p�l����\��.
            StartCoroutine(LoadNextGameWithDelay());
        }
        else
        {
            Debug.Log("���s�p�l����\��");
            failPanel.SetActive(true); //���s�p�l����\��.

            playerLife--; //���C�t�����炷.

            //���C�t��image���X�V.
            if(playerLife < images.Count)
            {
                images[playerLife].enabled = false;//playerLife�Ԗڂ̉摜��false.
            }

            //�Q�[���I�[�o�[����.
            if (playerLife <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
                return;
            }

            StartCoroutine(LoadNextGameWithDelay());
        }
    }

    //���̃Q�[���ɐi�ޏ���.
    private void LoadNextGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentIndex + 1);
    }

    // ���̃~�j�Q�[�������[�h����O�ɁA�x�����|����.
    private IEnumerator LoadNextGameWithDelay()
    {
        yield return new WaitForSeconds(PanelDelayTime); // �x������.

        succesPanel.SetActive(false); 

        failPanel.SetActive(false);

        LoadNextGame(); 

        StartNextGame();
    }

    //�p�l����Ԃ����Z�b�g.
    void StartNextGame()
    {
        succesPanel.SetActive(false);
        failPanel.SetActive(false);
    }



}

