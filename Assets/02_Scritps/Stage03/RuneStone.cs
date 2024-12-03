using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RUENSTONE_TYPE
{
    RED,
    YELLOW,
    GREEN,
    BLUE,
    PURPLE,
    BLACK,
    NONE
}
public enum LEFT_RIGHT
{
    LEFT,
    RIGHT,
    NONE
}
public enum RUNESTONE_NUMBER
{
    FIRST,
    SECOND,
    THIRD,
    FOURTH,
    NONE
}

public class RuneStone : MonoBehaviour
{

    public RUENSTONE_TYPE RUENSTONE_TYPE;
    public RUNESTONE_NUMBER RUNESTONE_NUMBER;


    public int runeStoneNumber;

    public bool isPlayer;
    //public bool isKeyE;

    public TextMeshProUGUI activityText;


    public RUENSTONE_TYPE ContinueRuen;
    public RUNESTONE_NUMBER numberRuen;

    public bool MoveLeft;
 
    // Start is called before the first frame update
    void Awake()
    {
        isPlayer = false;
        MoveLeft = false;


        ContinueRuen = RUENSTONE_TYPE.NONE;
        numberRuen = RUNESTONE_NUMBER.NONE;

        switch (numberRuen)
        {
            case RUNESTONE_NUMBER.FIRST:

                runeStoneNumber = 0;
                break;
            case RUNESTONE_NUMBER.SECOND:

                runeStoneNumber = 1;
                break;
            case RUNESTONE_NUMBER.THIRD:

                runeStoneNumber = 2;
                break;
            case RUNESTONE_NUMBER.FOURTH:

                runeStoneNumber = 3;
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ContinueRuen = RUENSTONE_TYPE;

                MoveLeft = !MoveLeft;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isPlayer = true;

            activityText.gameObject.SetActive(true);
            activityText.text = "[ E ]를 눌러 비석과 상호작용";
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isPlayer = false;

            activityText.gameObject.SetActive(false);
        }
    }
}
