using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerを動かす処理
public class Stage2PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animatior;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject player;//Player

    [SerializeField] float playerSpeed = 2.0f;//Playerのスピード

    [SerializeField] float jumpPower = 1.0f; //Playerのジャンプ力

    [SerializeField] Transform groundCheck; // 接地判定用の位置

    [SerializeField] float groundCheckRadius = 0.1f; // 接地判定の半径

    [SerializeField] LayerMask grondLayer; //地面のレイヤー

    private bool isGrounded;

    private float moveX; //Horizontal

    AudioSource audio;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatior = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    //プレイヤーの左右移動
    private void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2(moveX * playerSpeed, rb.velocity.y);

        rb.velocity = moving;

        //動いているときだけアニメーションを実行
        if(moving != Vector2.zero)
        {
            animatior.SetTrigger("ChangeTrigger");
        }

        ChangeDirectionAnim(); //プレイヤーの向き
    }

    //プレイヤーのジャンプ機能
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
            audio.Play();
            isGrounded = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, grondLayer);
    }

    //spriteRenderでプレイヤーの向きを変える
    private void ChangeDirectionAnim()
    {
        if (moveX > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX < 0)
        {
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // デバッグ用に接地判定の範囲を表示
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
