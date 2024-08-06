using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    public Image icon; // ������ �̹����� ǥ���� UI �̹���

    public void SetItem(string itemName, Sprite itemImage)
    {
        icon.sprite = itemImage;
        icon.enabled = true;
    }
}

