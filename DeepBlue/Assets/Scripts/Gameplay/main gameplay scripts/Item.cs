using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : ScriptableObject {
    public int itemStrenght;
    public int itemSpeed;
    public int itemID;
    public enum type{
        weapon,
        armor,
        consumable
    }
}
