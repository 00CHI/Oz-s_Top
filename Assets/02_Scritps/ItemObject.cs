using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemObject : MonoBehaviour
{
    public Item item;




    public bool tagScissor01;
    public bool tagScissor02;
    public bool tagScissor03;

    //InventoryManage

    public bool getMagicScissors;




    private void Awake()
    {

      
        getMagicScissors = false;
        tagScissor01 = false;
        tagScissor02 = false;
        tagScissor03 = false;
    }

    private void Update()
    {
        //Inventory
       




        //if (tagScissor01 == true && tagScissor02 == true && tagScissor03 == true)
        //{
        //    //Magicbutton = true;
        //    tagScissor01 = false;
        //    scissor01.gameObject.SetActive(false);

        //    tagScissor02 = false;
        //    scissor02.gameObject.SetActive(false);

        //    tagScissor03 = false;
        //    scissor03.gameObject.SetActive(false);

        //    //getMagicScissors = true;
        //}

        //������ ���� boolŸ�� �̿��ؼ� true�� ����� true�� ��쿡 �����۵�bool ture ��� tap�� ������ �� �������� ���̵��� ����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }


}
