using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player04 : MonoBehaviour
{
    //Scripts
    public NPC04_01 npc04;
    public NPC04_02 npc04_2;

    //Player move
    public float speed;
    public float jumpDown;
    public float jumpPower;
    public float maxSpeed;

    int inventoryCount = 0;

    //Sprite_Anim
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //_Scissor text control
    public TextMeshProUGUI prompText;
    //public TextMeshProUGUI textItemName;
    //public TextMeshProUGUI textItemDesc;

    //Scissor Control

    public bool tagScissor01 = false;
    public bool tagScissor02 = false;
    public bool tagScissor03 = false;
    public bool tagScissor04 = false;

    public bool getScissor01 = false;
    public bool getScissor02 = false;
    public bool getScissor03 = false;
    public bool getScissor04 = false;
    public bool getMagicScissor = false;

    bool isLight;
    bool isPortal5;


    public GameObject scissor01;
    public GameObject scissor02;
    public GameObject scissor03;
    public GameObject scissor04;

    public GameObject Image_scissor01;
    public GameObject Image_scissor02;
    public GameObject Image_scissor03;
    public GameObject Image_scissor04;
    public GameObject Image_MagicScissor;

    public GameObject inventoryPanel;
    public GameObject mergeButton;

    public GameObject lightHand;



    //Variable
    private float h = 0;
    private float j = 0;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //inventoryPanel.gameObject.SetActive(false);
        mergeButton.gameObject.SetActive(false);

        //_scissor
        Image_scissor01.gameObject.SetActive(false);
        Image_scissor02.gameObject.SetActive(false);
        Image_scissor03.gameObject.SetActive(false);
        Image_scissor04.gameObject.SetActive(false);
        Image_MagicScissor.gameObject.SetActive(false);

        lightHand.SetActive(false);


        //textItemName.gameObject.SetActive(false);
        //textItemDesc.gameObject.SetActive(false);
        prompText.gameObject.SetActive(false);
    }

    void Start()
    {
        //float h = npc04.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        //float j = npc04.isAction ? 0 : Input.GetAxisRaw("Jump");

        h = Input.GetAxisRaw("Horizontal");     
        j = Input.GetAxisRaw("Jump");
    }

    // Update is called once per frame
    void Update()
    {
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
        if (rigid.velocity.y < - 0.01f)
        {
            //false anim
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", false);

            // true anim
            anim.SetBool("isJumpdown", true);

            //Gravity Ctrl
            rigid.AddForce(Vector2.down * jumpDown * Time.deltaTime);
        }
        else if (rigid.velocity.y < -0.01f && rigid.velocity.x < -0.01f)
        {
            //false anim
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isIdle", false);

            // true anim
            anim.SetBool("isJumpdown", true);

            //Gravity Ctrl
            rigid.AddForce(Vector2.down * jumpDown * Time.deltaTime);
        }
        // Jump down -> Idle 
        else
        {
            anim.SetBool("isJumpdown", false);
            anim.SetBool("isIdle", true);
        }

        bool moveLeft = npc04.isAction ? false : Input.GetKeyDown(KeyCode.LeftArrow);
        bool moveRight = npc04.isAction ? false : Input.GetKeyDown(KeyCode.RightArrow);

        //Derection flip Sprite //Run Anim
        if (moveLeft)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveRight)
        {
            spriteRenderer.flipX = false;
        }

        //Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;     

        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventoryPanel.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Scissors
        if (Input.GetKeyDown(KeyCode.E) && tagScissor01 == true)
        {
            getScissor01 = true;
            scissor01.gameObject.SetActive(false);
            Image_scissor01.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && tagScissor02 == true)
        {
            getScissor02 = true;
            scissor02.gameObject.SetActive(false);
            Image_scissor02.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && tagScissor03 == true)
        {
            getScissor03 = true;
            scissor03.gameObject.SetActive(false);
            Image_scissor03.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && tagScissor04 == true)
        {
            getScissor04 = true;
            scissor04.gameObject.SetActive(false);
            Image_scissor04.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && tagScissor04 == true)
        {
            getScissor04 = true;
            scissor04.gameObject.SetActive(false);
            Image_scissor04.gameObject.SetActive(true);
        }
        if (getScissor01 == true && getScissor02 == true && getScissor03 == true && getScissor04 == true)
        {
            getMagicScissor = true;
            mergeButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && isLight)
        {
            lightHand.SetActive(true);
            npc04_2.light.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && isPortal5)
        {
            SceneManager.LoadScene("Stage5");

        }
        //Inventory
        if (Input.GetKeyDown(KeyCode.Tab) && inventoryCount == 0 && npc04.isTalk == false)
        {
            inventoryPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inventoryCount = 1;

        }
        else if (Input.GetKeyUp(KeyCode.Tab) && npc04.isTalk && npc04.isTalk == false)
        {
            inventoryPanel.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate()
    {
        //Move maxSpeed
        //float h = Input.GetAxisRaw("Horizontal");
        float h = npc04.isAction ? 0 : Input.GetAxisRaw("Horizontal");

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

    private void OnCollisionStay2D(Collision2D collision)
    {
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
                anim.SetBool("isJump", false);
            }
            else
            {
                anim.SetBool("isJump", false);
                anim.SetBool("isPull", false);
                anim.SetBool("isRun", true);
                anim.SetBool("isIdle", true);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Box Tag
        if (collision.gameObject.CompareTag("Box"))
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isPull", false);
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Scissor01"))
        {
            tagScissor01 = true;
            SetPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor02"))
        {
            tagScissor02 = true;
            SetPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor03"))
        {
            tagScissor03 = true;
            SetPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor04"))
        {
            tagScissor04 = true;
            SetPrompText();
        }

        if (collision.gameObject.CompareTag("Light"))
        {
            isLight = true;
            SetPrompText();
        }
        if (collision.gameObject.CompareTag("Portal05"))
        {
            isPortal5 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scissor01"))
        {
            tagScissor01 = false;
            OutPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor02"))
        {
            tagScissor02 = false;
            OutPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor03"))
        {
            tagScissor03 = false;
            OutPrompText();
        }
        if (collision.gameObject.CompareTag("Scissor04"))
        {
            tagScissor04 = false;
            OutPrompText();
        }
        if (collision.gameObject.CompareTag("Light"))
        {
            isLight = false;
            OutPrompText();
        }
        if (collision.gameObject.CompareTag("Portal05"))
        {
            isPortal5 = false;
        }
    }

    private void SetPrompText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = "[ E ]¸¦ ´­·¯ ¾ÆÀÌÅÛ È¹µæ";
    }
    private void OutPrompText()
    {
        prompText.gameObject.SetActive(false);
    }

    public void OnMergeButton()
    {
        Image_scissor01.gameObject.SetActive(false);
        Image_scissor02.gameObject.SetActive(false);
        Image_scissor03.gameObject.SetActive(false);
        Image_scissor04.gameObject.SetActive(false);
        Image_MagicScissor.gameObject.SetActive(true);
        getMagicScissor = true;
    }


}
