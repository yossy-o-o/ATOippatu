using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Effect��Collision����������
public class Enemy2EffectCollision : MonoBehaviour
{ 
    /*��邱��.
     * �X�^�[�g�ʒu�ƏI���ʒu�̏ꏊ���擾
     * �^�C�}�[�Aclamp�g�p���āA�i�s�x���擾����
     * lerp�Ŏ擾�������W���g���X���[�Y�ɓ�����
     * �R���[�`���ŁA�G�t�F�N�g�̏o���ɍ��킹�����Ԓ���
     * ���ł��鎞�Ԃ����߂�
     * 
     */


    [SerializeField] float effectLifeTime = 4.0f; //�����蔻��̏��Ŏ���.

    [SerializeField] Transform Effect6StartPointCollition; //�����蔻��̃X�^�[�g�ʒu.

    [SerializeField] Transform Effect6EndPointCollition; //�����蔻��̏I���ʒu.

    private float timer = 0.0f; //�G�t�F�N�g�̌o�ߎ���.

    Rigidbody rb;

    private float delayTime = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(EffectMove());
    }

    private IEnumerator EffectMove()
    {
        yield return new WaitForSeconds(delayTime);

        //�G�t�F�N�g�̌o�ߎ��Ԃ��AeffectLifeTime��菬����������A�J��Ԃ�.
        while (timer < effectLifeTime)
        {
            float t = Mathf.Clamp01(timer / effectLifeTime); //�G�t�F�N�g�̐i�s�x�����߂�

            Vector3 effectMoving = Vector3.Lerp(Effect6StartPointCollition.position, Effect6EndPointCollition.position, t);
            
            transform.position = effectMoving;

            timer += Time.deltaTime; // �^�C�}�[���X�V���邱�Ƃɂ���āAwhile�𔲂���

            yield return null; // 1�t���[���ҋ@.
        }

        Destroy(gameObject); // ���ʂ̃��C�t�^�C�����I��������I�u�W�F�N�g��j��.

    }
}
