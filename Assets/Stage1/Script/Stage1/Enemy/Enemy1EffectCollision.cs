using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EffectにCollisionを持たせる
public class Enemy1EffectCollision : MonoBehaviour
{ 
    /*やること
     * 移動速度
     * 
     * 何秒後に消える
     */

    [SerializeField] float effectSpeed  = 1.0f; //当たり判定の移動速度

    [SerializeField] float effectLifeTime = 4.0f; //当たり判定の消滅時間

    [SerializeField] Transform Effect6StartPointCollition; //当たり判定のスタート位置

    [SerializeField] Transform Effect6EndPointCollition; //当たり判定の終了位置

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
