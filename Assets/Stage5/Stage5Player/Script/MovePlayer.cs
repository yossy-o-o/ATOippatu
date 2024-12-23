using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage5のキャラクターが動く処理
public class MovePlayer : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2.0f;

    private float moveX;

    [SerializeField] float jumpForce = 4.0f;

    private bool isRunning;

    Rigidbody2D rb2D;

    Animator animator;

    SpriteRenderer spriteRenderer;

    AudioSource audio;

    [SerializeField] Transform groundCheck;

    [SerializeField] float groundCheckRadius = 0.1f;

    [SerializeField] LayerMask groundLayer;

    private bool isGrounded;

    private bool isFootStep = false;

    private bool isCheckSoundJump = false;

    private float footStepTime = 0.3f;

    [SerializeField] AudioSource jumpAudio;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2(moveX * playerSpeed, rb2D.velocity.y);

        rb2D.velocity = moving;

        if(!isFootStep && moving.magnitude > 0.01f)
        {
            StartCoroutine(PlayFootStepSound());
        }

        //アニメーションを制御
        if (moving != Vector2.zero)
        {
            animator.SetBool("RunTrigger", true);
        }
        else
        {
            animator.SetBool("RunTrigger", false);
        }

        PlayerChangeFlip();

    }

    private void PlayerChangeFlip()
    {
        if(moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if(!isCheckSoundJump)
            {
                StartCoroutine(PlayJumpSound());
            }

            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        // デバッグ用に接地判定の範囲を表示
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    //足音
    private IEnumerator PlayFootStepSound()
    {
        if(!isFootStep)
        {
            isFootStep = true;

            audio.Play();

            yield return new WaitForSeconds(footStepTime);

            isFootStep = false;
        }

    }

    private IEnumerator PlayJumpSound()
    {
        if (!isCheckSoundJump)
        {
            isCheckSoundJump = true;

            jumpAudio.Play();

            yield return new WaitForSeconds(footStepTime);

            isCheckSoundJump = false;
        }

    }

}
