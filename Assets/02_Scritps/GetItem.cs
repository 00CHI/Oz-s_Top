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
    public Sprite itemImage; // Inspector���� ���� �����ϰ� �մϴ�.

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
        // �κ��丮�� ������ �߰�
        inventory.AddItem(itemName, itemImage);

        // ���� ������Ʈ�� ����
        Destroy(gameObject);
    }
}