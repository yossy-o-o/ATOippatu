using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage5失敗処理
public class Stage5DamageJudge : MonoBehaviour
{
    [SerializeField] BulletScript bulletScript;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage5FontCollider"))
        {
            //Debug.Log("あたり");
            bulletScript.isShooting = false;

            Destroy(gameObject);

            GameManager.instance.HandleMiniGameResult(false);
        }
    }
}
