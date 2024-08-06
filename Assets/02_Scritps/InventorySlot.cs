using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    public Image icon; // 아이템 이미지를 표시할 UI 이미지

    public void SetItem(string itemName, Sprite itemImage)
    {
        icon.sprite = itemImage;
        icon.enabled = true;
    }
}

