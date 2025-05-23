using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2Playerの失敗判定
public class PlayerDamageJugement : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy = new List<GameObject>();

    //失敗判定
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stage2Enemy"))//敵に衝突したら
        {
            EnemyDestroy();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))// ステージから落ちたら
        {
            EnemyDestroy();
            GameManager.instance.HandleMiniGameResult(false);
        }
    }

    private void EnemyDestroy()
    {
        foreach(GameObject Enemys in enemy)
        {
            Destroy(Enemys);
        }
    }
}
