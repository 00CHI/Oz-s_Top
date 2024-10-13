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
        if(isPlayer == true)
        {

            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isStone", true);
                anim.SetTrigger("isStoneEffect");
                activityText.gameObject.SetActive(false);

                //Invoke("SetFalse()", 0.2f);

                redTilePosition = redTile.transform.position - new Vector3(0, moveDistance, 0);
                StartCoroutine(MoveRedTile(redTile));

            }
        }

    }

    IEnumerator MoveRedTile(GameObject redObj)
    {
        while(redObj.transform.position != redTilePosition)
        {
            redObj.transform.position = Vector3.MoveTowards(redObj.transform.position, redTilePosition, moveSpeed * Time.deltaTime);
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