using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    ItemObject itemObject;


    //Player move
    public float speed;
    public float jumpDown;
    public float jumpPower;
    public float maxSpeed;

    //Object
    public GameObject boxObject;
    public bool getScissor01 = false;
    public bool getScissor02 = false;
    public bool getScissor03 = false;

    public bool tagScissor01 = false;
    public bool tagScissor02 = false;
    public bool tagScissor03 = false;
    public GameObject mergeButton;

    //_Scissor text control
    public TextMeshProUGUI prompText;
    public TextMeshProUGUI textItemName;
    public TextMeshProUGUI textItemDesc;
    public enum InfoType { Scissor01, Scissor02, Scissor03 }
    public InfoType type;

    public GameObject scissor01;
    public GameObject scissor02;
    public GameObject scissor03;

    public GameObject Image_scissor01;
    public GameObject Image_scissor02;
    public GameObject Image_scissor03;
    public GameObject Image_MagicScissor;


    //Moving with flatform
    private bool isOnMovingPlatform = false;
    private Transform currentPlatform;

    //Sprite_Anim
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //Variable
    private float h = Input.GetAxisRaw("Horizontal");
    private float j = Input.GetAxisRaw("Jump");

    //UI
    public GameObject inventoryPanel;
    //public TextMeshProUGUI textItemName;
    //public TextMeshProUGUI textItemDesc;




    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryPanel.gameObject.SetActive(false);
        mergeButton.SetActive(false);

        //_Scissor
        Image_scissor01.gameObject.SetActive(false);
        Image_scissor02.gameObject.SetActive(false);
        Image_scissor03.gameObject.SetActive(false);
        Image_MagicScissor.gameObject.SetActive(false);

        textItemName.gameObject.SetActive(false);
        textItemDesc.gameObject.SetActive(false);

    }

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
        if (rigid.velocity.y < -0.01f)
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

        //Derection flip Sprite //Run Anim
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }

        // Player on Tile?
        if (isOnMovingPlatform)
        {
            // Player move with Tile
            Vector3 platformVelocity = currentPlatform.GetComponent<Collider>().GetComponent<Rigidbody2D>().velocity;
            rigid.velocity = new Vector2(platformVelocity.x, platformVelocity.y);
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

        //_Scissor

        if (tagScissor01 == true)
        {
            SetPrompText();

            if (Input.GetKeyDown(KeyCode.E))
            {
                


                Image_scissor01.gameObject.SetActive(true);
                getScissor01 = true;

                Destroy(scissor01, 0.2f);
            }

        }
        if (tagScissor01 == false)
        {
            OutPrompText();
        }



        if (tagScissor02 == true)
        {
            SetPrompText();

            if (Input.GetKeyDown(KeyCode.E))
            {

                Image_scissor02.gameObject.SetActive(true);
                getScissor02 = true;

                Destroy(scissor02, 0.2f);
            }
        }
        if (tagScissor02 == false)
        {
            OutPrompText();
        }

        if (tagScissor03 == true)
        {
            SetPrompText();

            if (Input.GetKeyDown(KeyCode.E))
            {

                Image_scissor03.gameObject.SetActive(true);
                getScissor03 = true;

                Destroy(scissor03, 0.2f);
            }
        }
        if (tagScissor03 == false)
        {
            OutPrompText();
        }

        if (getScissor01 == true && getScissor02 == true && getScissor03 == true)
        {
            mergeButton.SetActive(true);
        }
    }

    //_Scissor
    private void SetPrompText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = "[ E ]∏¶ ¥≠∑Ø æ∆¿Ã≈€ »πµÊ";
    }
    private void OutPrompText()
    {
        prompText.gameObject.SetActive(false);
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
                anim.SetBool("isJump", false);
            }
        }
        else
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isPull", false);
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", true);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingGround"))
        {

            StartCoroutine("MovingGroundCrtl");

            isOnMovingPlatform = true;
            currentPlatform = collision.transform;

            anim.SetBool("isJump", false);
            anim.SetBool("isJumpdown", false);

            //True
            anim.SetBool("isIdle", true);
        }

        if (collision.gameObject.CompareTag("Scissor01"))
        {
            tagScissor01 = true;
        }
        if (collision.gameObject.CompareTag("Scissor02"))
        {
            tagScissor02 = true;
        }
        if (collision.gameObject.CompareTag("Scissor03"))
        {
            tagScissor03 = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Player exit Tile?
        if (collision.gameObject.CompareTag("MovingGround"))
        {
            isOnMovingPlatform = false;
            currentPlatform = null;

            anim.SetBool("isJumpdown", false);


            //True
            anim.SetBool("isIdle", true);
        }

        //_Scissor
        if (collision.gameObject.CompareTag("Scissor01"))
        {
            tagScissor01 = false;
        }
        if (collision.gameObject.CompareTag("Scissor02"))
        {
            tagScissor02 = false;
        }
        if (collision.gameObject.CompareTag("Scissor03"))
        {
            tagScissor03 = false;
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

    IEnumerator MovingGroundCrtl()
    {
        while (gameObject.CompareTag("MovingGround"))
        {
            yield return new WaitForSeconds(0.2f);

            anim.SetBool("isJumpdown", false);
        }
    }

    public void OnMergeButtonClick()
    {
        Image_scissor01.SetActive(false);
        Image_scissor02.SetActive(false);
        Image_scissor03.SetActive(false);

        Image_MagicScissor.SetActive(true);
    }
}

