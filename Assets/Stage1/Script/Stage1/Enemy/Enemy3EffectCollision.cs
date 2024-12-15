using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

//effect‚Ì“–‚½‚è”»’è(—ûK‚Æ‚µ‚Ä‚à‚¤ˆê“x‘‚­)
public class Enemy3EffectCollision : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;

    [SerializeField] float effectLifeTime = 1.0f;

    private float timer = 0.0f;

    [SerializeField] float delayTime = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(EffectSystem());
    }

    private IEnumerator EffectSystem()
    {
        yield return new WaitForSeconds(delayTime);

        //ŒJ‚è•Ô‚µ
        while(timer < effectLifeTime)
        {
            float elapsedTime = Mathf.Clamp01(timer / effectLifeTime);

            Vector3 effectMove = Vector3.Lerp(startPosition.position, endPosition.position, elapsedTime);

            transform.position = effectMove;

            timer += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);

    }


}
