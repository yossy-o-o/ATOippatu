using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEditor.SearchService;

//�����A���s�𔻒肵�A�p�l���Ǘ���A�̗͊Ǘ��ȂǃQ�[���S�ʂ̏���
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �V���O���g����

    private int playerLife = 5; // �v���C���[�̃��C�t

    private int successCount = 0; // ���������Q�[���̐�

    [SerializeField] List<Image> images = new List<Image>(); // ���C�t��UI

    [SerializeField] GameObject successPanel; // �����p�l��

    [SerializeField] GameObject failPanel; // ���s�p�l��

    [SerializeField] GameObject resultPanel; // ���ʃp�l��

    [SerializeField] float panelDelayTime = 2f; // �p�l���̒x���\������

    [SerializeField] TextMeshProUGUI successCountText; // ��������\������e�L�X�g

    [SerializeField] TextMeshProUGUI highStageText; // �ō��L�^��\������e�L�X�g

    private const string HighStageRecordKey = "HighStage"; // PlayerPrefs �p�̃L�[

    private bool isGameOver = false; //���C�t���Ȃ��Ȃ��āA�Q�[���I�[�o�[�̔��f

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
    }

    // ���C�t���Ȃ��Ȃ����ꍇ�̏���
    public void HandleMiniGameResult(bool success)
    {
        if (success)
        {
            successCount++;

            ShowSuccessPanelWithSlideIn(); //�����p�l�����A�j���[�V�����ŕ\��

            if(isGameOver == false)
            {
                StartCoroutine(LoadNextGameWithDelay());
            }
        }
        else
        {

            ShowFailPanelWithSlideIn(); //���s�p�l����\��

            playerLife--; // ���C�t�����炷

            // ���C�t�̉摜���X�V
            if (playerLife >= 0 && playerLife < images.Count)
            {
                images[playerLife].enabled = false;
            }

            // �Q�[���I�[�o�[����
            if (playerLife <= 0)
            {
                isGameOver = true;
                ShowResult();
                return;
            }

            if(isGameOver == true)
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
        resultPanel.SetActive(true);

        successCountText.text = successCount.ToString(); // ��������\��

        highStageText.text = HighStageRecord().ToString(); // �ō����B�X�e�[�W��\��
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


    //Dotween���g�p���āASuccessPanel�ɃA�j���[�V����������
    private void ShowSuccessPanelWithSlideIn()
    {
        RectTransform rectTransform = successPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0 , Screen.height); //��ʊO�Ɉړ�

        successPanel.SetActive(true);

        rectTransform.DOAnchorPos(Vector2.zero , 0.5f); //0.5�b�ŉ�ʒ����Ɉړ�
    }

    //failPanel�ɃA�j���[�V����������
    private void ShowFailPanelWithSlideIn()
    {
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



}
