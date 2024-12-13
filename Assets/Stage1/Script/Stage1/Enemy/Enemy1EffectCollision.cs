using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Effect��Collision����������
public class Enemy1EffectCollision : MonoBehaviour
{ 
    /*��邱��
     * �ړ����x
     * 
     * ���b��ɏ�����
     */

    [SerializeField] float effectSpeed  = 1.0f; //�����蔻��̈ړ����x

    [SerializeField] float effectLifeTime = 4.0f; //�����蔻��̏��Ŏ���

    [SerializeField] Transform Effect6StartPointCollition; //�����蔻��̃X�^�[�g�ʒu

    [SerializeField] Transform Effect6EndPointCollition; //�����蔻��̏I���ʒu

    private float timer = 0.0f;

    Rigidbody rb;

    private float delayTime = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Destroy(gameObject, effectLifeTime);

        StartCoroutine(EffectMove());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator EffectMove()
    {
        yield return new WaitForSeconds(delayTime);

        while(timer < effectLifeTime)
        {
            float t = Mathf.Clamp01(timer / effectLifeTime);

            Vector3 effectMoving = Vector3.Lerp(Effect6StartPointCollition.position, Effect6EndPointCollition.position, t);

            transform.position = effectMoving;


        }

        
    }
}
