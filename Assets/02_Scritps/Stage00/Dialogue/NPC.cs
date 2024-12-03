using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //public Dialogue dialogueData;          // NPC 대화 데이터
    //public DialogueSystem dialogueSystem; // 대화 시스템 참조

    public DialogueManager2 dialogueManager;

    public GameObject dialogueBox;
    public GameObject inventoryPanel;
    public GameObject pandant;

    bool isPlayer = false;
    bool isTalk = false;
    public bool isAction;

    public int talkCount = 0;

    public GameObject[] illust;
    public Text talkText;
    public Text nameText;

    private void Awake()
    {
        pandant.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer)
        {
            //.StartDialogue(dialogueData); // 대화 시작
            talkCount += 1;
            Debug.Log(talkCount);
        }
        //North Witch
        else if (talkCount == 1)
        {
            isTalk = true;
            dialogueBox.SetActive(true);
            isAction = true;

            illust[2].SetActive(true);
            nameText.text = "북쪽 마녀";
            talkText.text = "안녕하세요. 저는 이 숲을 지키는 북쪽 마녀예요.";
        }
        else if(talkCount == 2)
        {
            talkText.text = "먼저 감사의 말씀을 드리고 싶네요. 저기 깔린 마녀는 숲과 동물을 괴롭히는 동쪽 마녀입니다.";
        }
        else if (talkCount == 3)
        {
            talkText.text = "이렇게 도움을 받게 되어 감사해요.";
        }
        //Doroshi
        else if(talkCount == 4)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 아, 아니에요! 우연이에요.";
        }
        else if (talkCount == 5)
        {
            talkText.text = "제 이름은 도로시예요! 이상한 태풍에 휘말려 여기까지 오게 되었어요. 혹시 캔자스 마을이 어딘지 아시나요?";
        }
        //North Witch
        else if (talkCount == 6)
        {
            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "북쪽 마녀";
            talkText.text = "캔자스 마을? 그런 마을은 처음 들어보네요. \n여기는 마법의 세계 오즈입니다. ";
        }
        else if (talkCount == 7)
        {
            talkText.text = "아무래도 태풍에 영향으로 다른 세계로 오신 거 같네요. 다른 세계에서 오신 분들이 종종 있죠.";
        }
        //Doroshi
        else if (talkCount == 8)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 정말인가요? 그럼 집에 돌아가는 방법을 아시나요?";
        }
        //North Witch
        else if (talkCount == 9)
        {
            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "북쪽 마녀";
            talkText.text = " 음… 이 세계로 오신 분들은 보통 에메랄드 탑에 갑니다.";
        }
        //Doroshi
        else if (talkCount == 10)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 에메랄드 탑이요?";
        }
        //North Witch
        else if (talkCount == 11)
        {
            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "북쪽 마녀";
            talkText.text = "네. 앞으로 계속 가면 에메랄드 탑이 있을 거예요. 탑 최상층에 도달하면 어떤 소원이든 빌 수 있지만";
        }
        else if (talkCount == 12)
        {
            talkText.text = "…다만 에메랄드 탑은 오르기가 힘들고 시련을 실패하면 저주에 걸릴 수도 있어요.";
        }
        //Doroshi
        else if (talkCount == 10)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 정말인가요? 그럼 어떡하죠…";
        }
        //North Witch
        else if (talkCount == 11)
        {
            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "북쪽 마녀";
            talkText.text = "보답으로 드릴게요 이걸 받으세요. 이 펜던트를 지니고 있으면 특별한 힘을 줄 거예요.";
        }
        else if (talkCount == 12)
        {
            talkText.text = "설령 탑을 오르지 못해도 특별한 일을 하면 이 펜던트에 빛이 나 부탁을 들어줄 거예요! \n(TAP을 눌러 인벤토리 오픈)";
        }
        //Doroshi
        else if (talkCount == 13)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 정말 감사합니다! 은혜는 잊지 않을게요. 마지막으로 강아지 못 보셨나요? 작은 갈색 강아지예요!";
        }
        //North Witch
        else if (talkCount == 14)
        {
            illust[0].SetActive(false);
            illust[2].SetActive(true);

            nameText.text = "북쪽 마녀";
            talkText.text = "여기선 다른 동물은 보지 못했네요. 미안해요.";
        }
        else if (talkCount == 15)
        {
            talkText.text = "요새 탑에 이상한 소문이 돌고 있어요. 제 동료인 서쪽 마녀도 조사하러 갔지만 아무런 소식이 없네요. 만약 보신다면 안부 부탁드려요.";
        }
        //Doroshi
        else if (talkCount == 16)
        {
            illust[2].SetActive(false);
            illust[0].SetActive(true);

            nameText.text = "도로시";
            talkText.text = " 명심할게요! 감사합니다.";
        }
        else if (talkCount > 16)
        {
            dialogueBox.SetActive(false);
            pandant.SetActive(true);

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
