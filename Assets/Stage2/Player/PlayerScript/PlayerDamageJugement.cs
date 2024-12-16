using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2Player‚Ì¸”s”»’è
public class PlayerDamageJugement : MonoBehaviour
{

    [SerializeField] GameObject enemy;

    //¸”s”»’è
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stage2Enemy"))//“G‚ÉÕ“Ë‚µ‚½‚ç
        {
            Destroy(enemy);
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))// ƒXƒe[ƒW‚©‚ç—‚¿‚½‚ç
        {
            Destroy(enemy);
            GameManager.instance.HandleMiniGameResult(false);
        }
    }
}
