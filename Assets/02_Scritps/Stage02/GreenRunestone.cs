using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenRunestone : MonoBehaviour
{


    //_Scissor text control
    public TextMeshProUGUI activityText;

    public GameObject Tile;
    public float moveSpeed = 2.0f;    // Ÿ���� �������� �ӵ�

    //private bool isMoving = false;    // Ÿ���� �����̴��� Ȯ���ϱ� ���� �÷���
    private Vector3 TilePosition; //Ÿ���� �̵��� ��ǥ ��ġ

    int stoneCount = 0;


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
        stoneCount = 0;

        activityText.gameObject.SetActive(false);
        //moveDistance = 1.5f; // Ÿ���� �������� �Ÿ�


        // ������ �� Ÿ�� ������Ʈ�� ���� ��ġ�� ����
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

            if (Input.GetKeyDown(KeyCode.E) && Tile.transform.position.y > 14.78f && stoneCount == 0)
            {
                stoneCount++;
                anim.SetBool("isStone", true);
                //anim.SetBool("isStoneEffect", true);
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                float moveDistance1 = 3.8f; // Ÿ���� �̵��ϴ� �Ÿ�

                TilePosition = Tile.transform.position - new Vector3(0, moveDistance1, 0);
                StartCoroutine(MoveRedTile(Tile));           
            }
            if (Input.GetKeyDown(KeyCode.E) && Tile.transform.position.y < 14.78f && stoneCount == 1)
            {
                float moveDistance2 = -3.8f; // Ÿ���� �̵��ϴ� �Ÿ�

                TilePosition = Tile.transform.position - new Vector3(0, moveDistance2, 0);
                StartCoroutine(MoveRedTile(Tile));
            }
        }    
    }

    IEnumerator MoveRedTile(GameObject greenObj)
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
