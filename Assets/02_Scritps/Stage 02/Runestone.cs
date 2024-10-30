using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Runestone : MonoBehaviour
{

    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject redTile;
    public float moveDistance; // Ÿ���� �������� �Ÿ�
    public float moveSpeed = 1.0f;    // Ÿ���� �������� �ӵ�
    private bool isMoving = false;    // Ÿ���� �����̴��� Ȯ���ϱ� ���� �÷���
    private Vector3 redTilePosition; //Ÿ���� �̵��� ��ǥ ��ġ

    //bool type
    public bool isPlayer = false;
    public bool isKeyE = false;

    //Sprite_Anim
    Animator anim;

    public enum COLORTILE
    {
        COLORTILE_redObj,
        COLORTILE_yellowObj,
        COLORTILE_greenObj,
        COLORTILE_blueObj,
        COLORTILE_puppleObj,
        COLORTILE_end
    }
    


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        isPlayer = false;
        isKeyE = false;

        activityText.gameObject.SetActive(false);
        moveDistance = 1.5f; // Ÿ���� �������� �Ÿ�


        // ������ �� Ÿ�� ������Ʈ�� ���� ��ġ�� ����
        if (redTile != null)
        {
            redTilePosition = redTile.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        COLORTILE colortile = COLORTILE.COLORTILE_end;

        switch (colortile)
        {
            case COLORTILE.COLORTILE_redObj:

                if (isPlayer == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anim.SetBool("isStone", true);
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        //Invoke("SetFalse()", 0.2f);

                        redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                        StartCoroutine(MoveRedTile(redTile));

                    }
                }
                break;
            case COLORTILE.COLORTILE_yellowObj:
                if (isPlayer == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anim.SetBool("isStone", true);
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        //Invoke("SetFalse()", 0.2f);

                        redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                        StartCoroutine(MoveRedTile(redTile));

                    }
                }
                break;
            case COLORTILE.COLORTILE_greenObj:
                if (isPlayer == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anim.SetBool("isStone", true);
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        //Invoke("SetFalse()", 0.2f);

                        redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                        StartCoroutine(MoveRedTile(redTile));

                    }
                }
                break;
            case COLORTILE.COLORTILE_blueObj:
                if (isPlayer == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anim.SetBool("isStone", true);
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        //Invoke("SetFalse()", 0.2f);

                        redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                        StartCoroutine(MoveRedTile(redTile));

                    }
                }
                break;
            case COLORTILE.COLORTILE_puppleObj:
                if (isPlayer == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        anim.SetBool("isStone", true);
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        //Invoke("SetFalse()", 0.2f);

                        redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                        StartCoroutine(MoveRedTile(redTile));

                    }
                }
                break;
        }
       

    }

    IEnumerator MoveRedTile(GameObject COLORTILE_redObj)
    {
        while(COLORTILE_redObj.transform.position != redTilePosition)
        {
            COLORTILE_redObj.transform.position = Vector3.MoveTowards(COLORTILE_redObj.transform.position, redTilePosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isPlayer = true;

            activityText.gameObject.SetActive(true);
            activityText.text = "[ E ]�� ���� �񼮰� ��ȣ�ۿ�";

        }


    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            activityText.gameObject.SetActive(false);
        }
    }

    //void SetTextFalse()
    //{
    //    activityText.gameObject.SetActive(false);

    //}

}
