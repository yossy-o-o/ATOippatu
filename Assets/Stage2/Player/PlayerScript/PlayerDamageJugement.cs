using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2Player‚Ì¸”s”»’è
public class PlayerDamageJugement : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy = new List<GameObject>();

    //¸”s”»’è
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stage2Enemy"))//“G‚ÉÕ“Ë‚µ‚½‚ç
        {
            EnemyDestroy();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))// ƒXƒe[ƒW‚©‚ç—‚¿‚½‚ç
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
