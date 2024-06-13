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
        talkData.Add(500, new string[] { "�ȳ��ϼ���. ���� �� ���� �����̵��� ��Ű�� ���� ���࿹��.\n�����̸� �������� ���� ���ฦ �����ּż� �����ؿ�." });
        talkData.Add(100, new string[] { "��� ��� ��������?, ������ġ�� ����.  " });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}


