using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;          // 대화를 표시할 UI 텍스트
    public Text characterNameText;     // 캐릭터 이름 표시용 텍스트
    public GameObject dialogueBox;     // 대화 UI 박스
    public GameObject[] illustImage;     // 대화 UI 박스
    public Dialogue dialogueData;      // 대화 데이터


    private Queue<DialogueLine> dialogueLines;   // 대화 큐

    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = new Queue<DialogueLine>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        dialogueLines.Clear();

        foreach (DialogueLine line in dialogue.lines)
        {
            dialogueLines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if(dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueLines.Dequeue();
        characterNameText.text = line.characterName;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(line.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    public Dialogue dialogue = new Dialogue
    {
        lines = new DialogueLine[]
    {
        new DialogueLine { characterName = "북쪽 마녀", sentence = "안녕하세요! 반갑습니다." },
        new DialogueLine { characterName = "북쪽 마녀", sentence = "안녕하세요! 저도 반갑습니다." },
        new DialogueLine { characterName = "도로시", sentence = "오늘 날씨가 참 좋네요." },
        new DialogueLine { characterName = "도로시", sentence = "그러게요. 정말 맑아요!" }
    }
    };

}
