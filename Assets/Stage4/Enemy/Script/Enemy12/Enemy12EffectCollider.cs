using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Effect12の当たり判定
public class Enemy12EffectCollider : MonoBehaviour
{
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

        while(true)
        {
            timer = 0.0f; //タイマーリセット

            while(timer < effectLifeTime)
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
