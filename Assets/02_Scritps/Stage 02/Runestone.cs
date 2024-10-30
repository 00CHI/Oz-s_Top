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
    public float moveDistance; // 타일이 내려오는 거리
    public float moveSpeed = 1.0f;    // 타일이 내려오는 속도
    private bool isMoving = false;    // 타일이 움직이는지 확인하기 위한 플래그
    private Vector3 redTilePosition; //타일이 이동할 목표 위치

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
        moveDistance = 1.5f; // 타일이 내려오는 거리


        // 시작할 때 타겟 오브젝트의 현재 위치를 저장
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
            activityText.text = "[ E ]를 눌러 비석과 상호작용";

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
