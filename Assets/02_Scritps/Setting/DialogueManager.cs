using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    //List<int> talkData;
    Dictionary<int, string> nameData;
    Dictionary<int, GameObject[]> illustData;

    public GameObject[] illustList;

    public int talkCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        //talkData = new List<int>();
        nameData = new Dictionary<int, string>();
        illustData = new Dictionary<int, GameObject[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        nameData.Add(100, new string("북쪽 마녀"));
        nameData.Add(2, new string("토토"));

        illustData.Add(2, new GameObject[] { illustList[1] });//TOTO

        //for (int northCount = 0; northCount == 0; northCount++)
        while (talkCount <= 10)
        {           
            if(talkCount == 0)
            {

                illustData.Add(100, new GameObject[] { illustList[2] });//NORTH_WITCH

                talkData.Add(100, new string[] { "안녕하세요, 저는 이 숲을 지키는 북쪽 마녀예요.",
                "먼저 감사의 말씀을 드리고 싶네요. 저기 깔린 마녀는 숲과 동물을 괴롭히는 동쪽 마녀입니다. \n이렇게 도움을 받게 되어 감사해요."});
                talkCount =1;
            }
            else if (talkCount == 1)
            {
                illustData.Add(1, new GameObject[] { illustList[0] });//DOROSHI
                nameData.Add(1, new string("도로시"));

                talkData.Add(1, new string[] { "아, 아니에요! 우연이에요.",
                "제 이름은 도로시예요! 이상한 태풍에 휘말려 여기까지 오게 되었어요. \n혹시 캔자스 마을이 어딘지 아시나요?" });
                talkCount = 2;
            }
            else if(talkCount == 2)
            {
                illustData.Add(100, new GameObject[] { illustList[2] });//NORTH_WITCH
                nameData.Add(100, new string("북쪽 마녀"));

                talkData.Add(1, new string[] { "캔자스 마을? 그런 마을은 처음 들어보네요. \n여기는 마법의 세계 오즈입니다.",
                "아무래도 태풍에 영향으로 다른 세계로 오신 거 같네요. 다른 세계에서 오신 분들이 종종 있죠."});
                talkCount = 3;
            }

        }

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
    public string GetName(int id, string name)//, int illustIndex
    {
        return nameData[id]+ name;
    }
    public GameObject GetIllust(int id, int illustIndex)//, int illustIndex
    {
        return illustData[id][illustIndex];
    }
          

}
