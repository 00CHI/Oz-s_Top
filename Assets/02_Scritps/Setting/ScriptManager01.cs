using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager01 : MonoBehaviour
{
    public DialogueManager2 dialogueManager;

    public GameObject illust;
    public Text talkText;
    public Text nameText;
    public GameObject scriptPanel;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public int illustIndex;
    //ublic string name;

    //GPT
    public Dialogue dialogueData;          // NPC 대화 데이터
    public DialogueSystem dialogueSystem;

    // Start is called before t1he first frame update

    private void Update()
    {

    }

    public void Action(GameObject scanObj)
    {

        if (dialogueManager.talkCount >= 10)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        //Talk(objData.id, objData.isNpc);

        scriptPanel.SetActive(isAction);




    }

    //void Talk(int id, bool isNpc)
    //{
    //    string talkData = dialogueManager.GetTalk(id, talkIndex);

    //    //if(talkData == null)

    //        if (dialogueManager.talkCount == 10)
    //        {
    //            isAction = false;
    //            talkIndex = 0;
    //            return;
    //        }
    //    isAction = true;
    //    talkIndex++;
    //}

}
