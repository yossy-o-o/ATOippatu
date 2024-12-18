using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EffectにCollisionを持たせる
public class Enemy2EffectCollision : MonoBehaviour
{
    /*やること.
     * スタート位置と終了位置の場所を取得
     * タイマー、clamp使用して、進行度を取得する
     * lerpで取得した座標を使いスムーズに動かす
     * コルーチンで、エフェクトの出現に合わせた時間調整
     * 消滅する時間を決める
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
            timer = 0.0f; //タイマーリセット

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
