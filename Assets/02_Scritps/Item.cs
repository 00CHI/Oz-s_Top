using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData data;
    Image icon;
    public TextMeshProUGUI textItemName;
    public TextMeshProUGUI textItemDesc;


    void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon; 
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textItemName.gameObject.SetActive(true);
        textItemDesc.gameObject.SetActive(true);

        textItemName.text = data.displayName;
        textItemDesc.text = data.description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스가 슬롯을 벗어날 때
        textItemName.gameObject.SetActive(false);
        textItemDesc.gameObject.SetActive(false);
    }
}
