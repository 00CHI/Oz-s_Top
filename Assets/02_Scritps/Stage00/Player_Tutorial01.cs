using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Tutorial01 : MonoBehaviour
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

    //Ray
    //public ScriptManager01 scriptManager01;
    public NPC npc;
    private Vector3 directVector;
    private GameObject scanObject;

    //Variable
    //private float h = 0;

    private bool isPortal01;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //Ray : Dialogue
        bool moveLeftRight = Input.GetButtonUp("Horizontal");
        bool moveLeft = npc.isAction ? false : Input.GetKeyDown(KeyCode.LeftArrow);
        bool moveRight = npc.isAction ? false : Input.GetKeyDown(KeyCode.RightArrow);

        //Run Animation
        if (rigid.velocity.normalized.x == 0)
        {
            anim.SetBool("isRun", false);
        }
        else if (rigid.velocity.normalized.x > 0 || rigid.velocity.normalized.x < 0)
        {
            anim.SetBool("isRun", true);
        }

        if (moveLeftRight)
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Derection flip Sprite //Run Anim
        if (moveLeft)
        {
            spriteRenderer.flipX = true;
            //Ray
            directVector = Vector3.left;
        }
        else if (moveRight)
        {
            spriteRenderer.flipX = false;
            //Ray
            directVector = Vector3.right;
        }

        if(Input.GetKeyDown(KeyCode.E) && isPortal01)
        {
            SceneManager.LoadScene("Stage0_1");
        }

        //Ray
        //if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        //{
        //    scriptManager01.Action(scanObject);
        //}
    }

    void FixedUpdate()
    {
        //Move maxSpeed
        float h = npc.isAction ? 0 : Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h * speed, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        else if (rigid.velocity.x < maxSpeed * (-1))//Left Max speed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        //Ray
        Debug.DrawRay(rigid.position, directVector * 0.9f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, directVector, 0.9f, LayerMask.GetMask("NPC"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(npc.talkCount >= 17 && collision.gameObject.CompareTag("Portal01"))
        {
            isPortal01 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (npc.talkCount < 17 || collision.gameObject.CompareTag("Portal01"))
        {
            isPortal01 = false;
        }
    }
}
