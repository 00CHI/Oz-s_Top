using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchDialogue : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("WitchDialogue_check");

            //GameObject panel = GameObject.FindWithTag("WitchDialogue");
            //if (panel == null)
            //{
            //    return;
            //}

            //panel.SetActive(true);
        }
    }
}
