using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EffectÇ…CollisionÇéùÇΩÇπÇÈ
public class Enemy1EffectCollision : MonoBehaviour
{ 
    /*Ç‚ÇÈÇ±Ç∆
     * à⁄ìÆë¨ìx
     * 
     * âΩïbå„Ç…è¡Ç¶ÇÈ
     */

    [SerializeField] float effectSpeed  = 1.0f;

    [SerializeField] float effectLifeTime = 4.0f;

    [SerializeField] Transform Effect3StartPointCollition;

    [SerializeField] Transform Effect3EndPointCollition;

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

        float t = Mathf.Clamp01(timer / effectLifeTime);

        Vector3 effectMoving = Vector3.Lerp(Effect3StartPointCollition.position, Effect3EndPointCollition.position, t);

        transform.position = effectMoving;
    }
}
