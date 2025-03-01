using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

//成功、失敗を判定し、パネル管理や、体力管理などゲーム全般の処理
public class GameManager : MonoBehaviour
{
    /*やること
     * シングルトン化して、共通化
     * ライフ(残機の数)決める
     * リストで画像を取得して
     * 
     */

    public static GameManager instance; // シングルトン化

    private int playerLife = 5; // プレイヤーのライフ

    [SerializeField] List<Image> images = new List<Image>(); // ライフのUI

    private int successCount = 0; // 成功したゲームの数

    [SerializeField] GameObject successPanel; // 成功パネル

    [SerializeField] GameObject failPanel; // 失敗パネル

    [SerializeField] GameObject resultPanel; // 結果パネル

    [SerializeField] float panelDelayTime = 2f; // パネルの遅延表示時間

    [SerializeField] TextMeshProUGUI successCountText; // 成功数を表示するテキスト

    [SerializeField] TextMeshProUGUI highStageText; // 最高記録を表示するテキスト

    private const string HighStageRecordKey = "HighStageRecord"; // PlayerPrefs 用のキー

    private bool isGameOver = false; //ライフがなくなって、ゲームオーバーの判断

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

        int currentStage = SceneManager.GetActiveScene().buildIndex; // 現在のシーンをステージ番号として記録

        UpdateHighScore(currentStage); // 最高記録を更新

        int highStage = PlayerPrefs.GetInt(HighStageRecordKey, 0);

    }

    // 各ミニゲームの成功、失敗を判定し、パネルを出す処理
    public void HandleMiniGameResult(bool success)
    {
        //もし成功だったら
        if (success)
        {
            successCount++; //記録用(パネルに表示)のカウントをプラス

            ShowSuccessPanelWithSlideIn(); //成功パネルをアニメーションで表示

            //ゲームオーバーじゃなかったら、次のシーンの読み込み
            if(isGameOver == false)
            {
                StartCoroutine(LoadNextGameWithDelay());
            }
        }
        else
        {
            //失敗処理

            ShowFailPanelWithSlideIn(); //失敗パネルを表示

            playerLife--; // ライフを減らす

            // プレイヤのライフが0以上かつ、イメージがそれより多かったら
            if (playerLife >= 0 && playerLife < images.Count)
            {
                images[playerLife].enabled = false;
            }

            // ゲームオーバー判定
            if (playerLife <= 0)
            {
                isGameOver = true; // ゲームオーバーにして

                ShowResult(); //リザルト処理

                return;
            }

            //ゲームオーバーじゃなかったら
            if(isGameOver == false)
            {
               StartCoroutine(LoadNextGameWithDelay());
            }
        }
    }

    // 次のゲームをロードする処理
    private IEnumerator LoadNextGameWithDelay()
    {
        yield return new WaitForSeconds(panelDelayTime);

        successPanel.SetActive(false);

        failPanel.SetActive(false);

        LoadNextGame();
    }

    //シーンの管理と、エンドレスにするための処理
    private void LoadNextGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        int nextIndex = currentIndex + 1;

        // シーンの総数を取得
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // 最後のシーンを超えたら最初のシーンに戻る
        if (nextIndex >= totalScenes)
        {
            nextIndex = 1; // 最初のシーンに戻る
        }

        SceneManager.LoadScene(nextIndex);
    }

    // ゲームオーバー後の結果を表示
    private void ShowResult()
    {   

        RectTransform rectTransform = resultPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0, Screen.height);

        resultPanel.SetActive(true); // リザルトパネル表示

        successCountText.text = successCount.ToString(); // 成功数を表示

        highStageText.text = HighStageRecord().ToString(); // 最高到達ステージを表示

        rectTransform.DOAnchorPos(Vector2.zero, 0.5f); //0.5秒で画面中央に移動
    }

    //Dotweenを使用して、SuccessPanelにアニメーションを入れる
    private void ShowSuccessPanelWithSlideIn()
    {
        successAudioSorce.Play();

        RectTransform rectTransform = successPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0 , Screen.height); //画面外に移動


        successPanel.SetActive(true);

        rectTransform.DOAnchorPos(Vector2.zero , 0.5f); //0.5秒で画面中央に移動
    }

    //failPanelにアニメーションを入れる
    private void ShowFailPanelWithSlideIn()
    {
        failAudioSorce.Play();

        RectTransform rectTransform = failPanel.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0 , Screen.height); //画面外に移動

        failPanel.SetActive(true);

        rectTransform.DOAnchorPos(Vector2.zero, 0.5f); //0.5秒で画面中央に移動
    }

    //リスタート処理
    public void RestartGame()
    {
        isGameOver = false; //GameOver状態をfalseに

        playerLife = 5; //プレイヤーライフをリセット

        successCount = 0; //成功数をリセット

        //ライフの画像をリセット
        foreach (var image in images)
        {
            image.enabled = true;
        }


        //全パネルをfalse
        successPanel.SetActive(false);
        failPanel.SetActive(false);
        resultPanel.SetActive(false);

        SceneManager.LoadScene(1);
    }

    // 最高記録を更新する
    private void UpdateHighScore(int currentStage)
    {
        int highStage = PlayerPrefs.GetInt(HighStageRecordKey, 0);

        if (currentStage > highStage)
        {
            PlayerPrefs.SetInt(HighStageRecordKey, currentStage);

            PlayerPrefs.Save();
        }
    }

    // 最高記録を取得
    public int HighStageRecord()
    {
        return PlayerPrefs.GetInt(HighStageRecordKey, 0);
    }



}
