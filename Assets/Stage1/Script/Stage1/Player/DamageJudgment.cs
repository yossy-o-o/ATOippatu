using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤにダメージ（攻撃）が入ったかの判定
public class DamageJudgment : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemy;


    //攻撃が当たったら、GameOverPanelを表示する
    //失敗処理
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Eff6AttackCollision"))
        {
            Debug.Log("当たった！");
            GameManager.instance.HandleMiniGameResult(false);// 失敗を通知
            DisableEnemy();
        }

        if(other.gameObject.CompareTag("Eff12AttackCollision"))
        {
            Debug.Log("当たった！");
            GameManager.instance.HandleMiniGameResult(false);// 失敗を通知
            DisableEnemy();

        }

        if(other.gameObject.CompareTag("Enemy1EffectCollision"))
        {
            Debug.Log("当たった！");
            GameManager.instance.HandleMiniGameResult(false);// 失敗を通知
            DisableEnemy();
        }
    }

    //リストに入ってるenemyをfalseにする
    public void DisableEnemy()
    {
        foreach (GameObject enemy in Enemy)
        {
            {
                if (enemy != null)
                {
                    enemy.SetActive(false);
                }
            }
        }
    }
}
