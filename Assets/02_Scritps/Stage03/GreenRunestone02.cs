using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenRunestone02 : MonoBehaviour
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

    //public int limitMove = 0;

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
        //moveDistance01 = 1.5f; // Ÿ���� �������� �Ÿ�


        // ������ �� Ÿ�� ������Ʈ�� ���� ��ġ�� ����
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
            
            if (Input.GetKeyDown(KeyCode.E) && count == 0)
            {
                count = 1;
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                TilePosition01 = Tile01.transform.position - new Vector3(0, moveDistance01, 0);
                StartCoroutine(MoveGreenTile(Tile01, TilePosition01));

                TilePosition02 = Tile02.transform.position - new Vector3(0, moveDistance02, 0);
                StartCoroutine(MoveGreenTile(Tile02, TilePosition02));

                TilePosition03 = Tile03.transform.position - new Vector3(0, moveDistance03, 0);
                StartCoroutine(MoveGreenTile(Tile03, TilePosition03));

                TilePosition04 = Tile04.transform.position - new Vector3(0, moveDistance04, 0);
                StartCoroutine(MoveGreenTile(Tile04, TilePosition04));
            }
            else if ( Input.GetKeyDown(KeyCode.E) && count == 1)
            {
                count = 0;
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                TilePosition01 = Tile01.transform.position - new Vector3(0, -moveDistance01, 0);
                StartCoroutine(MoveGreenTile(Tile01, TilePosition01));

                TilePosition02 = Tile02.transform.position - new Vector3(0, -moveDistance02, 0);
                StartCoroutine(MoveGreenTile(Tile02, TilePosition02));

                TilePosition03 = Tile03.transform.position - new Vector3(0, -moveDistance03, 0);
                StartCoroutine(MoveGreenTile(Tile03, TilePosition03));

                TilePosition04 = Tile04.transform.position - new Vector3(0, -moveDistance04, 0);
                StartCoroutine(MoveGreenTile(Tile04, TilePosition04));
            }
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