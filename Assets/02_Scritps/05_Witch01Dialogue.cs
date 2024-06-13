using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;
using System.IO.Pipes;

public class Witch01Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI witchTalk;
    [SerializeField]
    private GameObject panel;

    //Witch Check
    public bool isWitch = false;

    private void Start()
    {

    }
    void Update()
    {
        if(panel == true)
        {
            GenerateData();
        }
    }

    void GenerateData()
    {
        
       witchTalk.text = ("�ȳ��ϼ���. ���� �� ���� �����̵��� ��Ű�� ���� ���࿹��. \n�����̸� �������� ���� ���ฦ �����ּż� �����ؿ�.");
        //"��� �˰��־���� ��� ��������? \n������ġ�� ����. ";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWitch = true;
        }
        else
        {
            isWitch = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWitch = false;
        }

    }

}


