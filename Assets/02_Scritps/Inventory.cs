using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // �κ��丮 UI ������Ʈ
    public Transform itemsParent; // �κ��丮 UI ������ �����۵��� ������ �θ� ������Ʈ
    public GameObject inventorySlotPrefab; // �κ��丮 ���� ������

    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        inventoryUI.SetActive(false); // ���� ���� �� �κ��丮 UI�� ����ϴ�.
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

        inventoryUI.SetActive(true); // �������� �߰��� �� �κ��丮 UI�� �����ݴϴ�.
    }



}
