using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage5のキャラクターが動く処理
public class MovePlayer : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2.0f;

    private float moveX;

    private float jumpForce = 4.0f;

    private bool isRunning;

    Rigidbody2D rb2D;

    Animator animator;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2(moveX * playerSpeed, rb2D.velocity.y);

        rb2D.velocity = moving;

        //アニメーションを制御
        if (moving != Vector2.zero)
        {
            animator.SetBool("RunTrigger", true);
        }
        else
        {
            animator.SetBool("RunTrigger", false);
        }

    }



}
