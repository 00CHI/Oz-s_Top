using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NPC04_02 : MonoBehaviour
{
    //public Dialogue dialogueData;          // NPC 대화 데이터
    //public DialogueSystem dialogueSystem; // 대화 시스템 참조

    public NPC04_01 npc04;
    public Player04 player04;
    public GameObject dialogueBox;
    public GameObject cutSceneCanvas;

    public GameObject woodMan03;
    public GameObject magictree;
    public GameObject light;

    bool isPlayer = false;

    public int talkCount = 0;
    public int startCount = 0;

    bool isStage4;

    public GameObject[] illust;
    public Text talkText;
    public Text nameText;

    //string typingText;



    private void Awake()
    {
        isStage4 = true;

        cutSceneCanvas.SetActive(false);

    }
    private void Update()
    {
        //StartScript
        if (Input.GetKeyDown(KeyCode.E) && isPlayer && !player04.getMagicScissor)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(false);
            illust[2].SetActive(true);
            dialogueBox.SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "앞이 보이면 그나마 나을텐데.";

            npc04.isTalk = true;
        }
        else if (Input.GetKeyUp(KeyCode.E) && isPlayer && !player04.getMagicScissor)
        {

            illust[2].SetActive(false);
            dialogueBox.SetActive(false);

            nameText.text = null;
            talkText.text = null;

            npc04.isTalk = false;
        }

        //StartScript
        if (Input.GetKeyDown(KeyCode.E) && isPlayer && player04.getMagicScissor)
        {
            startCount += 1;
            npc04.isTalk = true;
        }
        //Woodman
        else if (startCount == 1)
        {
            illust[2].SetActive(true);
            dialogueBox.SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "(마법의 가위가 나무꾼의 긴 털을 잘라낸다.)";
        }
        else if (startCount == 2)
        {
            illust[2].SetActive(false);
            illust[3].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "고마워 조금씩 자라긴 하지만 계속 자르면 나아지겠어.";
        }
        //Doroshi
        else if (startCount == 3)
        {

            illust[3].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = "다행이네요. 혹시 괜찮으시다면 같이 올라가실래요? 저주를 풀 지 모르잖아요!";
        }
        //Woodman
        else if (startCount == 4)
        {
            illust[0].SetActive(false);
            illust[3].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "그래도 괜찮겠어? 너희만 괜찮다면 같이 올라가자.";
        }
        //Doroshi
        else if (startCount == 5)
        {

            illust[3].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = "지도로 보니 여기 앞으로 가면 돼요!";
        }
        //Woodman
        else if (startCount == 6)
        {
            illust[0].SetActive(false);
            illust[3].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "이 나무를 자르면 되겠지?";
        }
        //ScareCrow 
        else if (startCount == 7)
        {
            magictree.SetActive(false);
            light.SetActive(true);


            illust[3].SetActive(false);
            illust[1].SetActive(true);

            nameText.text = "소년";
            talkText.text = "다음 층은 어두워서 이 밝은 열매 챙겨가는 건 어때요?";
        }
        //Doroshi
        else if (startCount == 8)
        {
            illust[1].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = "그래 챙겨가자!";
        }
        else if (startCount >= 9)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(false);
            illust[2].SetActive(false);
            illust[3].SetActive(false);

            dialogueBox.SetActive(false);

            gameObject.SetActive(false);
            woodMan03.SetActive(true);

            npc04.isAction = false;
            npc04.isTalk = false;
        }
        //else if (talkCount >= 10)
        //{
            
        //}


    }

    //public static void TMPDOText(TMP_Text text, float duration)
    //{
    //    text.maxVisibleCharacters = 0;
    //    DOTween.To(x => text.maxVisibleCharacters = (int)x, 0f, text.text.Length, duration);
    //}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
               isPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
