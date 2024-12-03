using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;  // 화자 이름
    public string sentence;    // 대화 내용
    public GameObject illust;    // 캐릭터 일러스트
}
[System.Serializable]
public class Dialogue
{
    public DialogueLine[] lines; // 대화 줄들의 배열
}

