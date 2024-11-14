using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//public enum eTYPE
//{
//    NONE_TILE,
//    RED_TILE,
//    GREEN_TILE,
//    BULE_TILE,
//    PURPLE_TILE
//}

public class GreenRunestone02 : MonoBehaviour
{


    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject Tile01;
    public GameObject Tile02;
    public GameObject Tile03;
    public GameObject Tile04;

    public float moveDistance01; // 타일이 내려오는 거리
    public float moveDistance02; 
    public float moveDistance03; 
    public float moveDistance04; 

    public float moveSpeed = 1.0f;    // 타일이 내려오는 속도

    //private bool isMoving = false;    // 타일이 움직이는지 확인하기 위한 플래그
    private Vector3 TilePosition01; //타일이 이동할 목표 위치
    private Vector3 TilePosition02; 
    private Vector3 TilePosition03; 
    private Vector3 TilePosition04;

    private int count02 = 0;

    //public int limitMove = 0;

    //bool type
    public bool isPlayer = false;
    public bool isKeyE = false;

    //Sprite_Anim
    Animator anim;

    //public TYPE TYPE;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        isPlayer = false;
        isKeyE = false;

        activityText.gameObject.SetActive(false);
        //moveDistance01 = 1.5f; // 타일이 내려오는 거리


        // 시작할 때 타겟 오브젝트의 현재 위치를 저장
        if (Tile01 != null )
        {
            TilePosition01 = Tile01.transform.position;
            TilePosition02 = Tile02.transform.position;
            TilePosition03 = Tile03.transform.position;
            TilePosition04 = Tile04.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer == true)
        {
            //switch(TYPE)
            //{
               //case TYPE.GREEN_TILE:
                    if (Input.GetKeyDown(KeyCode.E) && count02 == 0)
                    {
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);

                        TilePosition01 = Tile01.transform.position - new Vector3(0, moveDistance01, 0);
                        StartCoroutine(MoveGreenTile(Tile01, TilePosition01));

                        TilePosition02 = Tile02.transform.position - new Vector3(0, moveDistance02, 0);
                        StartCoroutine(MoveGreenTile(Tile02, TilePosition02));

                        TilePosition03 = Tile03.transform.position - new Vector3(0, moveDistance03, 0);
                        StartCoroutine(MoveGreenTile(Tile03, TilePosition03));

                        TilePosition04 = Tile04.transform.position - new Vector3(0, moveDistance04, 0);
                        StartCoroutine(MoveGreenTile(Tile04, TilePosition04));

                        count02 = 1;

                    }
                    else if (Input.GetKeyDown(KeyCode.E) && count02 == 1)
                    {
                        anim.SetTrigger("isStoneEffect");
                        activityText.gameObject.SetActive(false);


                        TilePosition01 = Tile01.transform.position - new Vector3(0, -moveDistance01, 0);
                        StartCoroutine(MoveGreenTile(Tile01, TilePosition01));

                        TilePosition02 = Tile02.transform.position - new Vector3(0, -moveDistance02, 0);
                        StartCoroutine(MoveGreenTile(Tile02, TilePosition02));

                        TilePosition03 = Tile03.transform.position - new Vector3(0, -moveDistance03, 0);
                        StartCoroutine(MoveGreenTile(Tile03, TilePosition03));

                        TilePosition04 = Tile04.transform.position - new Vector3(0, -moveDistance04, 0);
                        StartCoroutine(MoveGreenTile(Tile04, TilePosition04));

                        count02 = 0;

                    }
                    //break;
            //}
            
        }


    }

    IEnumerator MoveGreenTile(GameObject greenObj, Vector3 TilePosition)
    {
        while(greenObj.transform.position != TilePosition)
        {
            greenObj.transform.position = Vector3.MoveTowards(greenObj.transform.position, TilePosition, moveSpeed * Time.deltaTime);
            
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
