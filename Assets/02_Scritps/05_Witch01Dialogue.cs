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
        witchTalk.text = "안녕하세요. 저는 이 숲과 난쟁이들을 지키는 북쪽 마녀예요.\n난쟁이를 괴롭히던 동쪽 마녀를 없애주셔서 감사해요.";
    }


}
