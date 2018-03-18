using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour {
    public int itemStrenght;
    public int itemSpeed;
    public int itemID;
    public string itemName;

    public type itemType;

    public enum type{
        weapon,
        armor,
        consumable
    };
}
