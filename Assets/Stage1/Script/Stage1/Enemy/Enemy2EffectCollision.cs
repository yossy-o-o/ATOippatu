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


    [SerializeField] Transform startPoint;

    [SerializeField] Transform endPoint;

    [SerializeField] float delayTime = 2.0f;

    [SerializeField] float effectLifeTime = 1.0f;

    private float timer = 0.0f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(effectMove());
    }

    private IEnumerator effectMove()
    {
        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            timer = 0.0f; //�^�C�}�[���Z�b�g

            while (timer < effectLifeTime)
            {
                float elapsedTime = Mathf.Clamp01(timer / effectLifeTime);

                Vector3 moving = Vector3.Lerp(startPoint.position, endPoint.position, elapsedTime);

                transform.position = moving;

                timer += Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(delayTime);
        }
    }

}
