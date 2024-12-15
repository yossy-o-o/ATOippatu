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


    [SerializeField] float effectLifeTime = 4.0f; //当たり判定の消滅時間.

    [SerializeField] Transform Effect6StartPointCollition; //当たり判定のスタート位置.

    [SerializeField] Transform Effect6EndPointCollition; //当たり判定の終了位置.

    private float timer = 0.0f; //エフェクトの経過時間.

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

        //エフェクトの経過時間が、effectLifeTimeより小さかったら、繰り返す.
        while (timer < effectLifeTime)
        {
            float t = Mathf.Clamp01(timer / effectLifeTime); //エフェクトの進行度を求める

            Vector3 effectMoving = Vector3.Lerp(Effect6StartPointCollition.position, Effect6EndPointCollition.position, t);
            
            transform.position = effectMoving;

            timer += Time.deltaTime; // タイマーを更新することによって、whileを抜ける

            yield return null; // 1フレーム待機.
        }

        Destroy(gameObject); // 効果のライフタイムが終了したらオブジェクトを破棄.

    }
}
