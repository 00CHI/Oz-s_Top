using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;

public class Witch01Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI witchTalk;

   public PanelTextSettings WitchDialogue;

    private void Start()
    {
        
    }
    void Update()
    {
        if(witchTalk != null)
        WitchText_01();
    }

    void WitchText_01()
    {
        witchTalk.text = "�ȳ��ϼ���. ���� �� ���� �����̵��� ��Ű�� ���� ���࿹��.\n�����̸� �������� ���� ���ฦ �����ּż� �����ؿ�.";
    }


}
