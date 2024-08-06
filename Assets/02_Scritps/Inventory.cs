using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // 인벤토리 UI 오브젝트
    public Transform itemsParent; // 인벤토리 UI 내에서 아이템들을 정렬할 부모 오브젝트
    public GameObject inventorySlotPrefab; // 인벤토리 슬롯 프리팹

    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        inventoryUI.SetActive(false); // 게임 시작 시 인벤토리 UI를 숨깁니다.
    }

    public void AddItem(string itemName, Sprite itemImage)
    {
        GameObject newSlot = Instantiate(inventorySlotPrefab, itemsParent);
        InventorySlot slot = newSlot.GetComponent<InventorySlot>();

        if (slot != null)
        {
            slot.SetItem(itemName, itemImage);
            slots.Add(slot);
        }

        inventoryUI.SetActive(true); // 아이템을 추가한 후 인벤토리 UI를 보여줍니다.
    }



}
