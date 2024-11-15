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

public class RuneStone : MonoBehaviour
{

    public RUENSTONE_TYPE RUENSTONE_TYPE;

    public int count = 0;

    public bool isPlayer;
    public bool isKeyE;

    public TextMeshProUGUI activityText;


    // Start is called before the first frame update
    void Awake()
    {
        isPlayer = false;
        isKeyE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                isKeyE = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                isKeyE = false;
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
