using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpDown;
    public float jumpPower;
    public float maxSpeed;

    public GameObject boxObject;

    //Anim
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //move  with Ground
    private bool isOnMovingPlatform = false;
    private Transform currentPlatform;



    float h = Input.GetAxisRaw("Horizontal");
    float j = Input.GetAxisRaw("Jump");


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isJumpdown", false);

            //true anim
            anim.SetBool("isIdle", true);
        }

        //Box Tag
        if (collision.gameObject.CompareTag("Box"))
        {
            float yGap = transform.position.y - collision.gameObject.transform.position.y;
            //Debug.LogError("GAP: " + yGap);

            if (yGap < 1)
            {
                anim.SetBool("isPull", true);
                anim.SetBool("isRun", false);
                anim.SetBool("isIdle", false);
            }
        }
        else
        {
            anim.SetBool("isPull", false);
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 움직이는 플랫폼과 충돌하는지 확인
        if (collision.gameObject.CompareTag("MovingGround"))
        {
            isOnMovingPlatform = false;
            currentPlatform = collision.transform;

        }
    }
    //수정중

    void OnCollisionExit2D(Collision2D collision)
    {
        // 플레이어가 움직이는 플랫폼을 떠났는지 확인
        if (collision.gameObject.CompareTag("MovingGround"))
        {
            isOnMovingPlatform = true;
            currentPlatform = collision.transform;

            //true anim
            anim.SetBool("isIdle", true);
        }
    }
    //수정중

    void Update()
    {
        if(isOnMovingPlatform)
        {
            Vector3 platformVelocity = currentPlatform.GetComponent<Rigidbody2D>().velocity;
            rigid.velocity = new Vector2(platformVelocity.x, rigid.velocity.y);
        }

        //Derection flip Sprite //Run Anim
        if (Input.GetButtonUp("Jump"))
        {
            anim.SetBool("isJumpdown", true);
        }

        //Run Animation
        if (rigid.velocity.normalized.x == 0)
        {
            anim.SetBool("isRun", false);
        }

        else if (rigid.velocity.normalized.x > 0 || rigid.velocity.normalized.x < 0)
        {
            anim.SetBool("isRun", true);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Jump /jump limited == && !anim.GetBool("isJump")
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump") && !anim.GetBool("isJumpdown"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isRun", false);

            //Jump Animation
            anim.SetBool("isJump", true);
        }


        //Jump Down
        if (rigid.velocity.y < -0.01f)
        {
            //false anim
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", false);

            // true anim
            anim.SetBool("isJumpdown", true);

            rigid.AddForce(Vector2.down * jumpDown * Time.deltaTime);
        }

        // Jump down -> Idle 방지
        else
        {
            anim.SetBool("isJumpdown", false);
            anim.SetBool("isIdle", true);
        }


        //Derection flip Sprite //Run Anim
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Move maxSpeed
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h * speed, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        else if (rigid.velocity.x < maxSpeed * (-1))//Left Max speed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }


}

