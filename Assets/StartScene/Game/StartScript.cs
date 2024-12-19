using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//スタートシーンのパネルを閉じて、ゲームシーンに入る
public class StartScript : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    [SerializeField] float delayTime = 3.0f;

    AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        StartCoroutine(DelayGameStart());
    }

    private IEnumerator DelayGameStart()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Play();

            yield return new WaitForSeconds(delayTime);


            startPanel.SetActive(false);

            SceneManager.LoadScene("Stage2Scene");
        }
    }
}
