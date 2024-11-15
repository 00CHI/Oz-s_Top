using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueRunestone02 : MonoBehaviour
{

    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject Tile01;
    public GameObject Tile02;
    public GameObject Tile03;

    public float moveDistance01; // 타일이 내려오는 거리
    public float moveDistance02; // 타일이 내려오는 거리
    public float moveDistance03; // 타일이 내려오는 거리

    public float moveSpeed = 1.0f;    // 타일이 내려오는 속도

    //private bool isMoving = false;    // 타일이 움직이는지 확인하기 위한 플래그
    private Vector3 TilePosition01; //타일이 이동할 목표 위치
    private Vector3 TilePosition02; //타일이 이동할 목표 위치
    private Vector3 TilePosition03; //타일이 이동할 목표 위치

    private int count = 0;

    public int limitMove;

    //bool type
    public bool isPlayer = false;
    public bool isKeyE = false;

    //Sprite_Anim
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        isPlayer = false;
        isKeyE = false;

        activityText.gameObject.SetActive(false);
        moveDistance01 = 1.5f; // 타일이 내려오는 거리


        // 시작할 때 타겟 오브젝트의 현재 위치를 저장
        if (Tile01 != null )
        {
            TilePosition01 = Tile01.transform.position;
            TilePosition02 = Tile02.transform.position;
            TilePosition03 = Tile03.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer == true)
        {
            
            if (Input.GetKeyDown(KeyCode.E)&& count == 0)
            {
                count = 1;
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                TilePosition01 = Tile01.transform.position - new Vector3(moveDistance01, 0 , 0);
                StartCoroutine(MoveRedTile(Tile01, TilePosition01));

                TilePosition02 = Tile02.transform.position - new Vector3(moveDistance02, 0, 0);
                StartCoroutine(MoveRedTile(Tile02, TilePosition02));

                TilePosition03 = Tile03.transform.position - new Vector3(0, moveDistance03, 0);
                StartCoroutine(MoveRedTile(Tile03, TilePosition03));
            }
            else if (Input.GetKeyDown(KeyCode.E) && count == 1)
            {
                count = 0;
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                TilePosition01 = Tile01.transform.position - new Vector3(-moveDistance01, 0, 0);
                StartCoroutine(MoveRedTile(Tile01, TilePosition01));

                TilePosition02 = Tile02.transform.position - new Vector3(-moveDistance02, 0, 0);
                StartCoroutine(MoveRedTile(Tile02, TilePosition02));

                TilePosition03 = Tile03.transform.position - new Vector3(0, -moveDistance03, 0);
                StartCoroutine(MoveRedTile(Tile03, TilePosition03));
            }
        }


    }

    IEnumerator MoveRedTile(GameObject blueObj, Vector3 TilePosition)
    {
        while(blueObj.transform.position != TilePosition)
        {
            blueObj.transform.position = Vector3.MoveTowards(blueObj.transform.position, TilePosition, moveSpeed * Time.deltaTime);
            
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
