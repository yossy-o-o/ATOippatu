using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2Player�̎��s����
public class PlayerDamageJugement : MonoBehaviour
{

    [SerializeField] GameObject enemy;

    //���s����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stage2Enemy"))//�G�ɏՓ˂�����
        {
            Destroy(enemy);
            GameManager.instance.HandleMiniGameResult(false);
        }

        if(other.gameObject.CompareTag("GameOverZone"))// �X�e�[�W���痎������
        {
            Destroy(enemy);
            GameManager.instance.HandleMiniGameResult(false);
        }
    }
}
