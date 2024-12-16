using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���K�Ƃ���Enemy9��Effect�����蔻��̏���
public class Enemy9Effect : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] Transform startPosition;

    [SerializeField] Transform endPosition;

    [SerializeField] float delayTime;

    [SerializeField] float effectLifeTime;

    private float timer = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(EffectSystem());
    }

    private IEnumerator EffectSystem()
    {
        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            timer = 0.0f;

            while (timer < effectLifeTime)
            {
                float elapsedTime = Mathf.Clamp01(timer / effectLifeTime);

                Vector3 effectMove = Vector3.Lerp(startPosition.position, endPosition.position, elapsedTime);

                transform.position = effectMove;

                timer += Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(delayTime);

        } 
    }
}
