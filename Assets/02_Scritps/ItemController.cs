using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public GameObject inventoryPanel;


    private void Update()
    {
        
    }

    
    
    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player")&& Input.GetKeyDown(KeyCode.R))
        {
           gameObject.SetActive(false);
        }
    }
}
