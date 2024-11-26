using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player01 : MonoBehaviour
{
    //Player move
    public float speed;
    public float jumpDown;
    public float jumpPower;
    public float maxSpeed;

    //Sprite_Anim
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //Variable
    private float h = 0;

    private bool isPortal01;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        h = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {


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

        //Derection flip Sprite //Run Anim
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isPortal01)
        {
            SceneManager.LoadScene("Stage2");
        }
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal01"))
        {
            isPortal01 = true;
        }


    }
}
