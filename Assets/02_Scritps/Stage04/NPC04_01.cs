using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NPC04_01 : MonoBehaviour
{
    //public Dialogue dialogueData;          // NPC 대화 데이터
    //public DialogueSystem dialogueSystem; // 대화 시스템 참조


    public GameObject dialogueBox;
    public GameObject cutSceneCanvas;
    public GameObject woodMan02;

    bool isPlayer = false;
    public bool isTalk = false;
    public bool isAction;

    public Player04 player04;

    public int talkCount = 0;
    public int startCount = 0;

    public int woodCount = 0;
    int talkSave;



    bool isStage4;

    public GameObject[] illust;
    public GameObject[] cutScene;
    public Image Fade;
    public Image cutSceneFade;
    public Text talkText;
    public Text nameText;

    //string typingText;

    public TMP_Text storyText;


    private void Awake()
    {
        isStage4 = true;

        cutSceneCanvas.SetActive(false);

    }
    private void Update()
    {
        if(isStage4 && startCount == 0)
        {
            Fade.DOFade(0.0f, 2);
            startCount = 1;
        }
        //StartScript
        if (Input.GetKeyDown(KeyCode.E) && startCount >= 1 && startCount <= 4)
        {
            startCount += 1;
            isTalk = true;
        }
        else if (startCount == 1)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(true);
            dialogueBox.SetActive(true);

            nameText.text = "소년";
            talkText.text = "와 금방 3층을 올라왔네요! 누나는 똑똑해요.";
        }
        //Doroshi
        else if (startCount == 2)
        {
            illust[0].SetActive(true);
            illust[1].SetActive(false);

            nameText.text = "도로시";
            talkText.text = "이 정도는 뭘~ 이어서 같이 올라갈까?";
        }
        //ScareCrow
        else if (startCount == 3)
        {

            illust[0].SetActive(false);
            illust[1].SetActive(true);

            nameText.text = "소년";
            talkText.text = "네! 여기 3층 지도예요!";
        }
        else if (startCount == 4 && talkCount != 1)
        {
            illust[0].SetActive(false);
            illust[1].SetActive(false);
            dialogueBox.SetActive(false);

            isTalk = false;
        }

        //First Woodman
        if (Input.GetKeyDown(KeyCode.E) && isPlayer)
        {
            //.StartDialogue(dialogueData); // 대화 시작
            talkCount += 1;
            Debug.Log(talkCount);
        }
        //Doroshi
        else if (talkCount == 1)
        {
            woodCount = 1;
            isTalk = true;
            dialogueBox.SetActive(true);
            isAction = true;

            illust[0].SetActive(false);
            illust[1].SetActive(true);
            nameText.text = "소년";
            talkText.text = "헉..! 저기 괴물이 있어요!";
        }
        //Woodman
        else if (talkCount == 2)
        {

            illust[1].SetActive(false);
            illust[2].SetActive(true);
            nameText.text = "나무꾼";
            talkText.text = "거기 누구 있습니까?";
        }
        //Doroshi
        else if (talkCount == 3)
        {

            illust[2].SetActive(false);
            illust[0].SetActive(true);
            nameText.text = "도로시";
            talkText.text = "괴물이라니 실례잖니… 아니 진짜 괴물이야!";
        }
        //ScareCrow
        else if (talkCount == 4)
        {

            illust[0].SetActive(false);
            illust[2].SetActive(true);
            nameText.text = "나무꾼";
            talkText.text = "아앗, 잠깐! 놀래켜서 미안해. 저주를 받았을 뿐이야…";
        }
        //Woodman
        else if (talkCount == 5)
        {

            illust[2].SetActive(false);
            illust[0].SetActive(true);
            nameText.text = "도로시";
            talkText.text = "어.. 안녕하세요. 저는 도로시예요. 아저씨는 누구세요?";
        }
        //WoodmanCutScene01
        else if (talkCount == 6)
        {
            dialogueBox.SetActive(false);
            cutSceneCanvas.SetActive(true);


            illust[0].SetActive(false);
            illust[1].SetActive(false);
            illust[2].SetActive(false);

            cutScene[0].SetActive(true);

            cutSceneFade.DOFade(0.0f, 2);


            nameText.text = null;
            talkText.text = null;

            storyText.text = "“나는 숲에 살고 있는 나무꾼이었어.”";
        }

        else if (talkCount == 7)
        {
            cutSceneFade.DOFade(1f, 0.5f);
        }
        //WoodmanCutScene02
        else if (talkCount == 8)
        {
            cutSceneFade.DOFade(0.0f, 2);

            cutScene[0].SetActive(false);
            cutScene[1].SetActive(true);

            cutSceneFade.DOFade(0.0f, 2);

            storyText.text = "“여느 때와 같이 나무를 베러 숲에 갔는데 그 곳엔 여인이 있었어.";

        }
        else if (talkCount == 9)
        {
            cutSceneFade.DOFade(1f, 0.5f);
        }
        //WoodmanCutScene03
        else if (talkCount == 10)
        {
            cutSceneFade.DOFade(0.0f, 2);

            cutScene[1].SetActive(false);
            cutScene[2].SetActive(true);

            storyText.text = "“그녀는 매일 같이 그 자리에 있었고 처음에는 호기심이었지만.”";
        }
        else if (talkCount == 11)
        {
            cutSceneFade.DOFade(1f, 0.5f);
        }
        //WoodmanCutScene04
        else if (talkCount == 12)
        {
            cutSceneFade.DOFade(0.0f, 2);

            cutScene[2].SetActive(false);
            cutScene[3].SetActive(true);

            nameText.text = null;
            talkText.text = null;
            storyText.text = "“점차 사랑에 빠지게 되었어.”";
        }
        else if (talkCount == 13)
        {
            cutSceneFade.DOFade(1f, 0.5f);
        }
        //WoodmanCutScene05
        else if (talkCount == 14)
        {
            cutSceneFade.DOFade(0.0f, 2);

            cutScene[3].SetActive(false);
            cutScene[4].SetActive(true);

            nameText.text = null;
            talkText.text = null;
            storyText.text = "“난 말재주가 없고 외모의 자신감이 없어서” \n에메랄드 탑에 오르게 되었지만";
        }
        else if (talkCount == 15)
        {
            cutSceneFade.DOFade(1f, 0.5f);

            cutScene[4].SetActive(true);
        }
        //Woodman
        else if (talkCount == 16)
        {

            dialogueBox.SetActive(true);
            cutSceneCanvas.SetActive(false);

            illust[2].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "저주를 받고, 지금 이 모습이 되었지.";
            storyText.text = null;
        }
        //Doroshi
        else if (talkCount == 17)
        {

            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = "그렇군요.. 제가 도울 방법은 없을까요?";
        }
        //Woodman
        else if (talkCount == 18)
        {

            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "앞만 보인다면 그나마 나을텐데. 자를 도구 같은 건 없니?";
        }
        //ScareCrow
        else if (talkCount == 19)
        {

            illust[2].SetActive(false);
            illust[1].SetActive(true);

            nameText.text = "소년";
            talkText.text = " 이 근처에 가위 조각을 본 거 같은데 그걸 조합하면 자를 수 있지 않을까요?";
        }
        //Doroshi
        else if (talkCount == 20)
        {

            illust[1].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = "한 번 찾아볼까?";
        }
        //Woodman
        else if (talkCount == 21)
        {

            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "나무꾼";
            talkText.text = "그럼 나는 저 위 나무 앞에 있을게, 부탁해. ";
        }
        else if (talkCount == 22)
        {
            dialogueBox.SetActive(false);
            gameObject.SetActive(false);
            woodMan02.SetActive(true);

            isAction = false;
            isTalk = false;
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
