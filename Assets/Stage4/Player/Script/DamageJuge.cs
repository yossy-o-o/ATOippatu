using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UŒ‚‚ğó‚¯‚ÄA¸”s‚·‚é”»’è
public class DamageJuge : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Stage4Eff12EnemyCollider"))
        {
            EnemySetFalse();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if (other.gameObject.CompareTag("Stage4Eff5EnemyCollider"))
        {
            EnemySetFalse();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("Stage4Eff8EnemyCollider"))
        {
            EnemySetFalse();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))
        {
            EnemySetFalse();
            GameManager.instance.HandleMiniGameResult(false);
        }
    }

    private void EnemySetFalse()
    {
        foreach (GameObject Enemy in enemy)
        {
            Enemy.SetActive(false);
        }
    }
}
