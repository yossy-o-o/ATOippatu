using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2Player�̎��s����
public class PlayerDamageJugement : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy = new List<GameObject>();

    //���s����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stage2Enemy"))//�G�ɏՓ˂�����
        {
            EnemyDestroy();
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))// �X�e�[�W���痎������
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
