using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player�𓮂�������
public class Stage2PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animatior;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject player;//Player

    [SerializeField] float playerSpeed = 2.0f;//Player�̃X�s�[�h

    [SerializeField] float jumpPower = 1.0f; //Player�̃W�����v��

    [SerializeField] Transform groundCheck; // �ڒn����p�̈ʒu

    [SerializeField] float groundCheckRadius = 0.1f; // �ڒn����̔��a

    [SerializeField] LayerMask grondLayer; //�n�ʂ̃��C���[

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

    //�v���C���[�̍��E�ړ�
    private void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2(moveX * playerSpeed, rb.velocity.y);

        rb.velocity = moving;

        //�����Ă���Ƃ������A�j���[�V���������s
        if(moving != Vector2.zero)
        {
            animatior.SetTrigger("ChangeTrigger");
        }

        ChangeDirectionAnim(); //�v���C���[�̌���
    }

    //�v���C���[�̃W�����v�@�\
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

    //spriteRender�Ńv���C���[�̌�����ς���
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
        // �f�o�b�O�p�ɐڒn����͈̔͂�\��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
