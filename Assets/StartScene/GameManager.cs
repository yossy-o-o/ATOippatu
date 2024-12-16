using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ミニゲーム成功、失敗処理を管理するスクリプト.
public class GameManager : MonoBehaviour
{
    /*やること
     * 
     * 全部のミニゲームに共通するので、シングルトン化
     * それぞれのシーンを取得する
     * ライフ(残機)の個数
     * 一定時間生き残ったらで成功失敗判定を行っていて、一元管理できるのでタイマーを実装
     * 結果をパネルを表示、成功したら次のステージ、失敗したらライフを減らして次のステージをロード
     * それぞれのシーンで、成功失敗のフラグを取得して、GameMangerに通知
     * 一定回数繰り返して生き残っていたらクリア、失敗
     * 時間があったらエンドレス実装
     * 
     */

    public static GameManager instance; //シングルトン化.

    private int playerLife = 5; //プレイヤのライフ.

    [SerializeField] List<Image> images = new List<Image>();//リストでimageを取得.

    [SerializeField] GameObject succesPanel; //成功パネル.

    [SerializeField] GameObject failPanel; //失敗パネル.

    [SerializeField] float PanelDelayTime = 3f;


    void Awake()
    {
        //インスタンス化
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

    //ライフが全部なくなり、GameOverの処理を行う.
    public void HandleMiniGameResult(bool success)
    {

        if (success)
        {
            Debug.Log("成功パネルを表示");
            succesPanel.SetActive(true);//成功パネルを表示.
            StartCoroutine(LoadNextGameWithDelay());
        }
        else
        {
            Debug.Log("失敗パネルを表示");
            failPanel.SetActive(true); //失敗パネルを表示.

            playerLife--; //ライフを減らす.

            //ライフのimageを更新.
            if(playerLife < images.Count)
            {
                images[playerLife].enabled = false;//playerLife番目の画像をfalse.
            }

            //ゲームオーバー判定.
            if (playerLife <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
                return;
            }

            StartCoroutine(LoadNextGameWithDelay());
        }
    }

    //次のゲームに進む処理.
    private void LoadNextGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentIndex + 1);
    }

    // 次のミニゲームをロードする前に、遅延を掛ける.
    private IEnumerator LoadNextGameWithDelay()
    {
        yield return new WaitForSeconds(PanelDelayTime); // 遅延時間.

        succesPanel.SetActive(false); 

        failPanel.SetActive(false);

        LoadNextGame(); 

        StartNextGame();
    }

    //パネル状態をリセット.
    void StartNextGame()
    {
        succesPanel.SetActive(false);
        failPanel.SetActive(false);
    }



}

