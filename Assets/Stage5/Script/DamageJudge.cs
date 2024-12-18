using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage5���s����
public class Stage5DamageJudge : MonoBehaviour
{
    [SerializeField] BulletScript bulletScript;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage5FontCollider"))
        {
            //Debug.Log("������");
            bulletScript.isShooting = false;

            Destroy(gameObject);

            GameManager.instance.HandleMiniGameResult(false);
        }
    }
}
