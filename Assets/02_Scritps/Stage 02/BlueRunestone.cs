using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueRunestone : MonoBehaviour
{


    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject Tile;
    public float moveSpeed = 2.0f;    // 타일이 내려오는 속도
    //private bool isMoving = false;    // 타일이 움직이는지 확인하기 위한 플래그
    private Vector3 TilePosition; //타일이 이동할 목표 위치

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
        //moveDistance = 1.5f; // 타일이 내려오는 거리


        // 시작할 때 타겟 오브젝트의 현재 위치를 저장
        if (Tile != null)
        {
            TilePosition = Tile.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == true)
        {

            if (Input.GetKeyDown(KeyCode.E)&& Tile.transform.position.y > 13.76f)
            {
                anim.SetBool("isStone", true);
                //anim.SetBool("isStoneEffect", true);
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);
    
                float moveDistance = 4f; // 타일이 이동는 거리

                TilePosition = Tile.transform.position - new Vector3(0, moveDistance, 0);
                StartCoroutine(MoveRedTile(Tile));
            }
        }    
    }

    IEnumerator MoveRedTile(GameObject blueObj)
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
