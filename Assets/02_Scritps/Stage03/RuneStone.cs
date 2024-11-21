using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RUENSTONE_TYPE
{
    RED,
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

public class RuneStone : MonoBehaviour
{

    public RUENSTONE_TYPE RUENSTONE_TYPE;

    public int count = 0;

    public bool isPlayer;
    //public bool isKeyE;

    public TextMeshProUGUI activityText;

    public RUENSTONE_TYPE ContinueRuen;
    public bool MoveLeft;

    // Start is called before the first frame update
    void Awake()
    {
        isPlayer = false;

        ContinueRuen = RUENSTONE_TYPE.NONE;
        MoveLeft = false;
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
