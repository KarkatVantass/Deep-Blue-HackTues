using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterItems : MonoBehaviour {
    int backpackSize = 30;
    public List<Item> Consumables = new List<Item>();
    public List<Item> Armor = new List<Item>();
    public List<Item> Weapons = new List<Item>();
    

    public void useConsumable(string consumableName)
    {
        int index;
        index = -1;
        foreach (var c in Consumables)
        {
            if(c.itemName == consumableName)
            {
                break;
            }
            index++;
        }
        if(index < 0)
        {
            this.gameObject.GetComponent<Combat>().hitPoints += Consumables[index].itemStrenght;
            if(this.gameObject.GetComponent<Combat>().hitPoints > 100)
            {
                this.gameObject.GetComponent<Combat>().hitPoints = 100;
            }
            Consumables.RemoveAt(index);
        }
    }
}
