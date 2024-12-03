using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NPC05 : MonoBehaviour
{
    //public Dialogue dialogueData;          // NPC 대화 데이터
    //public DialogueSystem dialogueSystem; // 대화 시스템 참조


    public GameObject dialogueBox;
    public GameObject inventoryPanel;
    public GameObject cutSceneCanvas;
    public GameObject[] pandant;

    bool isPlayer = false;
    bool isTalk = false;
    public bool isAction;

    public int talkCount = 0;

    public GameObject[] illust;
    public GameObject[] cutScene;
    public Image Fade;
    public Text talkText;
    public Text nameText;

    //string typingText;

    public TMP_Text storyText;


    private void Awake()
    {
        cutSceneCanvas.SetActive(false);
        pandant[0].SetActive(true);
        pandant[1].SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer)
        {
            //.StartDialogue(dialogueData); // 대화 시작
            talkCount += 1;
            Debug.Log(talkCount);
        }
        //Doroshi
        else if (talkCount == 1)
        {
            isTalk = true;
            dialogueBox.SetActive(true);
            isAction = true;

            illust[0].SetActive(true);
            illust[1].SetActive(false);
            nameText.text = "도로시";
            talkText.text = "꼬마야 안녕? 난 도로시라고 해. 무슨 일 있니?";
        }
        //ScareCrow
        else if (talkCount == 2)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(true);
            illust[1].transform.DOShakePosition(1f, 2f);
            nameText.text = "소년";
            talkText.text = "으아아아앙!";
        }
        //Doroshi
        else if (talkCount == 3)
        {
            illust[0].SetActive(true);
            illust[1].SetActive(false);
            nameText.text = "도로시";
            talkText.text = "어..? 괜찮아? 무슨 일이야.";
        }
        //ScareCrow
        else if (talkCount == 4)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(true);
            illust[1].transform.DOShakePosition(1f, 2f);
            nameText.text = "소년";
            talkText.text = "저 좀 도와주세요.";
        }
        //ScareCutScene01
        else if (talkCount == 5)
        {
            dialogueBox.SetActive(false);
            cutSceneCanvas.SetActive(true);


            illust[0].SetActive(false);
            illust[1].SetActive(false);

            cutScene[0].SetActive(true);

            Fade.DOFade(0.0f, 2);


            nameText.text = null;
            talkText.text = null;

            storyText.text = "”저희 집은 남들보다 가난해 학교를 갈 기회가 없었어요”";
        }
        else if (talkCount == 6)
        {
            cutScene[0].SetActive(true);
            Fade.DOFade(0.0f, 2);


            nameText.text = null;
            talkText.text = null;
            storyText.text = "”그래도 저는 공부하는게 재밌어서 버려진 책을 주우면서 공부를 했어요.”";

        }
        else if (talkCount == 7)
        {
            Fade.DOFade(1f, 0.5f);
        }
        //ScareCutScene02
        else if (talkCount == 8)
        {
            Fade.DOFade(0.0f, 2);

            cutScene[0].SetActive(false);
            cutScene[1].SetActive(true);

            Fade.DOFade(0.0f, 2);


            nameText.text = null;
            talkText.text = null;
            storyText.text = "“ 책을 주으러 쓰레기장에 가다가 들은 소문인데“ \n에메랄드 탑은 어떤 소원을 들어준다는 거에요.";

        }
        else if (talkCount == 9)
        {
            Fade.DOFade(1f, 0.5f);
        }
        //ScareCutScene03
        else if (talkCount == 10)
        {
            Fade.DOFade(0.0f, 2);

            cutScene[1].SetActive(false);
            cutScene[2].SetActive(true);

            nameText.text = null;
            talkText.text = null;
            storyText.text = "“ 더 이상 쓰레기를 줍지 않고 탑을 오르면 된다는“ \n마음에 들떠 준비도 못한 채 왔고.";
        }
        else if (talkCount == 11)
        {
            Fade.DOFade(1f, 0.5f);
        }
        //ScareCutScene04
        else if (talkCount == 12)
        {
            Fade.DOFade(0.0f, 2);

            cutScene[2].SetActive(false);
            cutScene[3].SetActive(true);

            nameText.text = null;
            talkText.text = null;
            storyText.text = "“ 결국 저주에 받아...“";
        }
        else if (talkCount == 13)
        {
            Fade.DOFade(1f, 0.5f);
        }
        //ScareCutScene05
        else if (talkCount == 14)
        {
            Fade.DOFade(0.0f, 2);

            cutScene[3].SetActive(false);
            cutScene[4].SetActive(true);

            nameText.text = null;
            talkText.text = null;
            storyText.text = "“ 지금까지 공부했던 내용들을 전부 잊고 책도 못 읽게 됐어요.“";

        }
        else if (talkCount == 15)
        {
            Fade.DOFade(1f, 0.5f);

            cutScene[4].SetActive(true);
        }
        //ScareCrow
        else if (talkCount == 16)
        {

            dialogueBox.SetActive(true);
            cutSceneCanvas.SetActive(false);

            illust[0].SetActive(false);
            illust[1].SetActive(true);

            nameText.text = "소년";
            talkText.text = "부모님이 걱정하실 텐데 탑 밖으로 나가지 못하는 상황이 되었어요. 도와주실 수 있나요?";
            storyText.text = null;
        }
        //ScareCrow
        else if (talkCount == 17)
        {
            illust[0].SetActive(true);
            illust[1].SetActive(false);

            nameText.text = "도로시";
            talkText.text = "같이 올라갈까? 내 팬던트의 힘으로 너도 같이 올라올 수 있을거야.";
        }
        //ScareCrow
        else if (talkCount == 18)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(true);

            nameText.text = "소년";
            talkText.text = "감사합니다! 답례로 3층 지도를 드릴게요. 전 이제 지도를 봐도 뭔지 모르겠어요.\n('S'를 눌러 지도를 확인)";
        }
        else if (talkCount > 19)
        {
            dialogueBox.SetActive(false);
            pandant[1].SetActive(true);

            isAction = false;
            isTalk = false;

        }
        //Inventory
        if (!isTalk && Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventoryPanel.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

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
