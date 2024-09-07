using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ItemType
//{
//    Resource,
//    Equipable,
//    Consumable
//}


////// 소모 아이템 사용 시 변경될 Conditions
////public enum ConsumableTypes
////{
////    Hunger,
////    Health
////}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    //public ItemType type;
    public Sprite itemIcon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}

