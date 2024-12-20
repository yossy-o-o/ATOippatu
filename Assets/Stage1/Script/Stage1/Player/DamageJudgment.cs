using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���Ƀ_���[�W�i�U���j�����������̔���
public class DamageJudgment : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemy;


    //�U��������������AGameOverPanel��\������
    //���s����
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Eff6AttackCollision"))
        {
            Debug.Log("���������I");
            GameManager.instance.HandleMiniGameResult(false);// ���s��ʒm
            DisableEnemy();
        }

        if(other.gameObject.CompareTag("Eff12AttackCollision"))
        {
            Debug.Log("���������I");
            GameManager.instance.HandleMiniGameResult(false);// ���s��ʒm
            DisableEnemy();

        }

        if(other.gameObject.CompareTag("Enemy1EffectCollision"))
        {
            Debug.Log("���������I");
            GameManager.instance.HandleMiniGameResult(false);// ���s��ʒm
            DisableEnemy();
        }
    }

    //���X�g�ɓ����Ă�enemy��false�ɂ���
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
