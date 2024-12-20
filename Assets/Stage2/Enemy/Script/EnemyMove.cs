using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の動き
public class EnemyMove : MonoBehaviour
{
    /*やること
     * やりたい事・敵をランダムな位置で一定時間動かし続ける
     * 
     * ステート駆動で、敵の行動を制限する
     * Run,Attck.Jumpでステートの定義
     * それぞれをswitchで処理
     * アニメーションをその中に入れて(trigger or direction)
     * 呼び出し処理
     * 敵がランダムな方向に行くときに、Runを呼び出す
     * playerとの距離は、player.position - enemypositioで求める
     * それをdirectionに入れて、directionの距離で決める
     * 
     */

    Animator animator;

    Rigidbody2D rb2D;

    SpriteRenderer spriteRenderer;

    [SerializeField] Transform target; //playerのposition

    [SerializeField] float chaseSpeed = 2.0f; //プレイヤーに向かって進むスピード

    [SerializeField] float chaseRange = 5.0f; // 走る継続時間

    [SerializeField] float attackRange = 1.0f; //攻撃距離

    [SerializeField] float footStepTime = 0.1f;

    private bool isFootStep = false;

    AudioSource audio;


    //ステートの種類
    private enum EnemyState
    {
        Run, //走る
        Attack, //攻撃する
    }

    private EnemyState currentState = EnemyState.Run;

    private void Start()
    {
        animator = GetComponent<Animator>();

        rb2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        EnemySwitch();

        StateAisSystem();
    }

    private void EnemySwitch()
    {
        switch(currentState)
        {
            case EnemyState.Run:
                Run();
                break;

            case EnemyState.Attack:
                Attack();
                break;
        }


    }

    //それぞれのstateに移行するための処理
    private void StateAisSystem()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        switch(currentState)
        {
            //ChaseRangeよりattackRangeのほうが大きかったら
            case EnemyState.Run:
                if(chaseRange <= attackRange)
                {
                    Debug.Log("距離" + distanceToPlayer);
                    changeState(EnemyState.Attack); //AttackStateに切り替える
                }
                break;

            //AttackRangeよりdistanceToPlayer大きいかつ、AttackStateの時、
            case EnemyState.Attack:
                if(distanceToPlayer > attackRange && chaseRange <= attackRange) //distance距離
                {
                    changeState(EnemyState.Run); //RunStateに切り替える
                }
                break;
        }
    } 
    //走る処理
    void Run()
    {
        if(!isFootStep)
        {
            StartCoroutine(footStepSE());
        }

        Vector2 direction = (target.position - transform.position).normalized;


        rb2D.velocity = direction * chaseSpeed;

        if(rb2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(rb2D.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    //攻撃処理
    void Attack()
    {

        animator.SetTrigger("Attack");

        rb2D.velocity = Vector2.zero;
    }


    //ジャンプ処理

    private void changeState(EnemyState newState)
    {
        if (currentState == newState) return;

        currentState = newState;

        // 状態ごとの初期化
        switch (newState)
        {
            case EnemyState.Attack:
                rb2D.velocity = Vector2.zero; // 攻撃中は停止
                break;

            case EnemyState.Run:
                break;
        }
    }


    private IEnumerator footStepSE()
    {
        isFootStep = true;

        audio.Play();

        yield return new WaitForSeconds(footStepTime);

        isFootStep = false;
    }
}
