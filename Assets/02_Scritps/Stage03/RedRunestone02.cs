using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//public enum TYPE
//{
//    NONE_TILE,
//    RED_TILE,
//    GREEN_TILE,
//    PURPLE_TILE,

//}

public class RedRunestone02 : MonoBehaviour
{

    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject Tile01;
    public GameObject Tile02;
    public GameObject Tile03;
    public GameObject Tile04;

    public float moveDistance01; // Ÿ���� �������� �Ÿ�
    public float moveDistance02; 
    public float moveDistance03; 
    public float moveDistance04;

    public float moveSpeed = 1.0f;    // Ÿ���� �������� �ӵ�

    //private bool isMoving = false;    // Ÿ���� �����̴��� Ȯ���ϱ� ���� �÷���
    private Vector3 TilePosition01; //Ÿ���� �̵��� ��ǥ ��ġ
    private Vector3 TilePosition02; 
    private Vector3 TilePosition03; 
    private Vector3 TilePosition04;

    private int count = 0;

    public int limitMove;
        

    //bool type
    public bool isPlayer = false;
    public bool isKeyE = false;

    //eTYPE Type = eTYPE.NONE_TILE;

    //public eTYPE TYPE;
      //public TYPE TYPE;



    //Sprite_Anim
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        isPlayer = false;
        isKeyE = false;

        activityText.gameObject.SetActive(false);
        //moveDistance01 = 1.5f; // Ÿ���� �������� �Ÿ�


        //������ �� Ÿ�� ������Ʈ�� ���� ��ġ�� ����
        if (Tile01 != null)
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
            if (Input.GetKeyDown(KeyCode.R) && count == 0)
            {
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                TilePosition01 = Tile01.transform.position - new Vector3(moveDistance01, 0, 0);
                StartCoroutine(MoveRedTile(Tile01, TilePosition01));


                TilePosition02 = Tile02.transform.position - new Vector3(moveDistance02, 0, 0);
                StartCoroutine(MoveRedTile(Tile02, TilePosition02));


                TilePosition03 = Tile03.transform.position - new Vector3(0, moveDistance03, 0);
                StartCoroutine(MoveRedTile(Tile03, TilePosition03));


                TilePosition04 = Tile04.transform.position - new Vector3(0, moveDistance04, 0);
                StartCoroutine(MoveRedTile(Tile04, TilePosition04));


                count = 1;
            }
            else if (Input.GetKeyDown(KeyCode.R) && count == 1)
            {
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                TilePosition01 = Tile01.transform.position - new Vector3(-moveDistance01, 0, 0);
                StartCoroutine(MoveRedTile(Tile01, TilePosition01));


                TilePosition02 = Tile02.transform.position - new Vector3(-moveDistance02, 0, 0);
                StartCoroutine(MoveRedTile(Tile02, TilePosition02));


                TilePosition03 = Tile03.transform.position - new Vector3(0, -moveDistance03, 0);
                StartCoroutine(MoveRedTile(Tile03, TilePosition03));


                TilePosition04 = Tile04.transform.position - new Vector3(0, -moveDistance04, 0);
                StartCoroutine(MoveRedTile(Tile04, TilePosition04));


                count = 0;

            }

        }
    }

    IEnumerator MoveRedTile(GameObject Obj, Vector3 TilePosition)
    {
        //WaitForSeconds ws = new WaitForSeconds(0.1f);

        //while(true)
        //{
           // yield return ws;

            //if (Type == TYPE)
            //{
                while (Obj.transform.position != TilePosition)
                {
                    Obj.transform.position = Vector3.MoveTowards(Obj.transform.position, TilePosition, moveSpeed * Time.deltaTime);
                    yield return null;


                }

        //}
        // }
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

}
