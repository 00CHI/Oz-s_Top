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

        //아이템 정리 bool타입 이용해서 true로 만들기 true일 경우에 아이템도bool ture 라면 tap을 눌렀을 떄 아이템이 보이도록 설정
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }


}
