using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

//�����A���s�𔻒肵�A�p�l���Ǘ���A�̗͊Ǘ��ȂǃQ�[���S�ʂ̏���
public class GameManager : MonoBehaviour
{
    /*��邱��
     * �V���O���g�������āA���ʉ�
     * ���C�t(�c�@�̐�)���߂�
     * ���X�g�ŉ摜���擾����
     * 
     */

    public static GameManager instance; // �V���O���g����

    private int playerLife = 5; // �v���C���[�̃��C�t

    [SerializeField] List<Image> images = new List<Image>(); // ���C�t��UI

    private int successCount = 0; // ���������Q�[���̐�

    [SerializeField] GameObject successPanel; // �����p�l��

    [SerializeField] GameObject failPanel; // ���s�p�l��

    [SerializeField] GameObject resultPanel; // ���ʃp�l��

    [SerializeField] float panelDelayTime = 2f; // �p�l���̒x���\������

    [SerializeField] TextMeshProUGUI successCountText; // ��������\������e�L�X�g

    [SerializeField] TextMeshProUGUI highStageText; // �ō��L�^��\������e�L�X�g

    private const string HighStageRecordKey = "HighStageRecord"; // PlayerPrefs �p�̃L�[

    private bool isGameOver = false; //���C�t���Ȃ��Ȃ��āA�Q�[���I�[�o�[�̔��f

    [SerializeField] AudioSource successAudioSorce;

    [SerializeField] AudioSource failAudioSorce;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        int currentStage = SceneManager.GetActiveScene().buildIndex; // ���݂̃V�[�����X�e�[�W�ԍ��Ƃ��ċL�^

        UpdateHighScore(currentStage); // �ō��L�^���X�V

        int highStage = PlayerPrefs.GetInt(HighStageRecordKey, 0);

    }

    // �e�~�j�Q�[���̐����A���s�𔻒肵�A�p�l�����o������
    public void HandleMiniGameResult(bool success)
    {
        //����������������
        if (success)
        {
            successCount++; //�L�^�p(�p�l���ɕ\��)�̃J�E���g���v���X

            ShowSuccessPanelWithSlideIn(); //�����p�l�����A�j���[�V�����ŕ\��

            //�Q�[���I�[�o�[����Ȃ�������A���̃V�[���̓ǂݍ���
            if(isGameOver == false)
            {
                StartCoroutine(LoadNextGameWithDelay());
            }
        }
        else
        {
            //���s����

            ShowFailPanelWithSlideIn(); //���s�p�l����\��

            playerLife--; // ���C�t�����炷

            // �v���C���̃��C�t��0�ȏォ�A�C���[�W�������葽��������
            if (playerLife >= 0 && playerLife < images.Count)
            {
                images[playerLife].enabled = false;
            }

            // �Q�[���I�[�o�[����
            if (playerLife <= 0)
            {
                isGameOver = true; // �Q�[���I�[�o�[�ɂ���

                ShowResult(); //���U���g����

                return;
            }

            //�Q�[���I�[�o�[����Ȃ�������
            if(isGameOver == false)
            {
               StartCoroutine(LoadNextGameWithDelay());
            }
        }
    }

    // ���̃Q�[�������[�h���鏈��
    private IEnumerator LoadNextGameWithDelay()
    {
        yield return new WaitForSeconds(panelDelayTime);

        successPanel.SetActive(false);

        failPanel.SetActive(false);

        LoadNextGame();
    }

    //�V�[���̊Ǘ��ƁA�G���h���X�ɂ��邽�߂̏���
    private void LoadNextGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        int nextIndex = currentIndex + 1;

        // �V�[���̑������擾
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // �Ō�̃V�[���𒴂�����ŏ��̃V�[���ɖ߂�
        if (nextIndex >= totalScenes)
        {
            nextIndex = 1; // �ŏ��̃V�[���ɖ߂�
        }

        SceneManager.LoadScene(nextIndex);
    }

    // �Q�[���I�[�o�[��̌��ʂ�\��
    private void ShowResult()
    {   

        RectTransform rectTransform = resultPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0, Screen.height);

        resultPanel.SetActive(true); // ���U���g�p�l���\��

        successCountText.text = successCount.ToString(); // ��������\��

        highStageText.text = HighStageRecord().ToString(); // �ō����B�X�e�[�W��\��

        rectTransform.DOAnchorPos(Vector2.zero, 0.5f); //0.5�b�ŉ�ʒ����Ɉړ�
    }

    //Dotween���g�p���āASuccessPanel�ɃA�j���[�V����������
    private void ShowSuccessPanelWithSlideIn()
    {
        successAudioSorce.Play();

        RectTransform rectTransform = successPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0 , Screen.height); //��ʊO�Ɉړ�


        successPanel.SetActive(true);

        rectTransform.DOAnchorPos(Vector2.zero , 0.5f); //0.5�b�ŉ�ʒ����Ɉړ�
    }

    //failPanel�ɃA�j���[�V����������
    private void ShowFailPanelWithSlideIn()
    {
        failAudioSorce.Play();

        RectTransform rectTransform = failPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0 , Screen.height); //��ʊO�Ɉړ�

        failPanel.SetActive(true);

        rectTransform.DOAnchorPos(Vector2.zero, 0.5f); //0.5�b�ŉ�ʒ����Ɉړ�
    }

    //���X�^�[�g����
    public void RestartGame()
    {
        isGameOver = false; //GameOver��Ԃ�false��

        playerLife = 5; //�v���C���[���C�t�����Z�b�g

        successCount = 0; //�����������Z�b�g

        //���C�t�̉摜�����Z�b�g
        foreach (var image in images)
        {
            image.enabled = true;
        }


        //�S�p�l����false
        successPanel.SetActive(false);
        failPanel.SetActive(false);
        resultPanel.SetActive(false);

        SceneManager.LoadScene(1);
    }

    // �ō��L�^���X�V����
    private void UpdateHighScore(int currentStage)
    {
        int highStage = PlayerPrefs.GetInt(HighStageRecordKey, 0);

        if (currentStage > highStage)
        {
            PlayerPrefs.SetInt(HighStageRecordKey, currentStage);

            PlayerPrefs.Save();
        }
    }

    // �ō��L�^���擾
    public int HighStageRecord()
    {
        return PlayerPrefs.GetInt(HighStageRecordKey, 0);
    }



}
