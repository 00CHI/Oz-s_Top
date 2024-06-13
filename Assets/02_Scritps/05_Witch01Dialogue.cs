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
        
       witchTalk.text = ("안녕하세요. 저는 이 숲과 난쟁이들을 지키는 북쪽 마녀예요. \n난쟁이를 괴롭히던 동쪽 마녀를 없애주셔서 감사해요.");
        //"사실 알고있었어요 언니 범인이죠? \n거짓말치지 마요. ";
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


