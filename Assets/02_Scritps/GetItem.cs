using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetItem : MonoBehaviour
{
    public Inventory inventory;

    //...Key List...
    public KeyCode keyZ = KeyCode.Z;


    public string itemName = "Scissor 01";
    public Sprite itemImage; // Inspector에서 설정 가능하게 합니다.

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        // 인벤토리에 아이템 추가
        inventory.AddItem(itemName, itemImage);

        // 현재 오브젝트를 제거
        Destroy(gameObject);
    }
}