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
    Dictionary <int, string[]> talkData;

    [SerializeField]
    private TextMeshProUGUI witchTalk;

    public PanelTextSettings WitchDialogue;


    private void Awake()
    {
        talkData = new Dictionary <int, string[]>();
        GenerateData();
    }
    private void Start()
    {
        
    }
    void Update()
    {

    }

    void GenerateData()
    {
        talkData.Add(500, new string[] { "안녕하세요. 저는 이 숲과 난쟁이들을 지키는 북쪽 마녀예요.\n난쟁이를 괴롭히던 동쪽 마녀를 없애주셔서 감사해요." });
        talkData.Add(100, new string[] { "언니 사실 범인이죠?, 거짓말치지 마요.  " });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}


