using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�̓���
public class EnemyMove : MonoBehaviour
{
    /*��邱��
     * ��肽�����E�G�������_���Ȉʒu�ň�莞�ԓ�����������
     * 
     * �X�e�[�g�쓮�ŁA�G�̍s���𐧌�����
     * Run,Attck.Jump�ŃX�e�[�g�̒�`
     * ���ꂼ���switch�ŏ���
     * �A�j���[�V���������̒��ɓ����(trigger or direction)
     * �Ăяo������
     * �G�������_���ȕ����ɍs���Ƃ��ɁARun���Ăяo��
     * player�Ƃ̋����́Aplayer.position - enemypositio�ŋ��߂�
     * �����direction�ɓ���āAdirection�̋����Ō��߂�
     * 
     */

    Animator animator;

    Rigidbody2D rb2D;

    SpriteRenderer spriteRenderer;

    [SerializeField] Transform target; //player��position

    [SerializeField] float chaseSpeed = 2.0f; //�v���C���[�Ɍ������Đi�ރX�s�[�h

    [SerializeField] float chaseRange = 5.0f; // ����p������

    [SerializeField] float attackRange = 1.0f; //�U������

    [SerializeField] float footStepTime = 0.1f;

    private bool isFootStep = false;

    AudioSource audio;


    //�X�e�[�g�̎��
    private enum EnemyState
    {
        Run, //����
        Attack, //�U������
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

    //���ꂼ���state�Ɉڍs���邽�߂̏���
    private void StateAisSystem()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        switch(currentState)
        {
            //ChaseRange���attackRange�̂ق����傫��������
            case EnemyState.Run:
                if(chaseRange <= attackRange)
                {
                    Debug.Log("����" + distanceToPlayer);
                    changeState(EnemyState.Attack); //AttackState�ɐ؂�ւ���
                }
                break;

            //AttackRange���distanceToPlayer�傫�����AAttackState�̎��A
            case EnemyState.Attack:
                if(distanceToPlayer > attackRange && chaseRange <= attackRange) //distance����
                {
                    changeState(EnemyState.Run); //RunState�ɐ؂�ւ���
                }
                break;
        }
    } 
    //���鏈��
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

    //�U������
    void Attack()
    {

        animator.SetTrigger("Attack");

        rb2D.velocity = Vector2.zero;
    }


    //�W�����v����

    private void changeState(EnemyState newState)
    {
        if (currentState == newState) return;

        currentState = newState;

        // ��Ԃ��Ƃ̏�����
        switch (newState)
        {
            case EnemyState.Attack:
                rb2D.velocity = Vector2.zero; // �U�����͒�~
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
