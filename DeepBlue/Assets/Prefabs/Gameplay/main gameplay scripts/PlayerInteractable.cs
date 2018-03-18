using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInteractable : MonoBehaviour {

    public GameObject pref = null;
    public float interactionRange = 1000000;
    public float speedEffect = 50;
    Collider currSelected = null;

	void Update()
    {
        Find();
        if (Input.GetKeyDown("space") && currSelected != null)
        {
            Interact();
        }
	}
    void Find()
    {
        bool isFound = false;
        Collider[] obj = Physics.OverlapSphere(this.transform.position, interactionRange);
        Collider closest=null;
        if (obj.Length > 0)
        {
            Debug.Log("hi");

            try
            {
                closest = obj
                    .OrderBy((Collider o) => Vector3.Distance(transform.position, o.transform.position))
                    .First();
            }
            catch
            {
                Debug.Log(obj[0]);
            }
        }


        
        if (currSelected != closest && currSelected != null)
        {
            currSelected.GetComponentInParent<Interactable>().Deselect();
        }
        currSelected = closest;
        if (currSelected != null)
        {
            currSelected.GetComponentInParent<Interactable>().Select();
        }
        isFound = true;

        if (!isFound)
        {
            if (currSelected != null)
            {
                currSelected.GetComponentInParent<Interactable>().Deselect();
            }
            currSelected = null;
        }
    }
    void Interact()
    {
        GameObject thisItem =  Instantiate(pref);
        thisItem.AddComponent<Item>(); 



        thisItem.GetComponent<Item>().itemName = currSelected.gameObject.GetComponentInParent<Item>().name;
        thisItem.GetComponent<Item>().itemSpeed = currSelected.gameObject.GetComponentInParent<Item>().itemSpeed;
        thisItem.GetComponent<Item>().itemStrenght = currSelected.gameObject.GetComponentInParent<Item>().itemStrenght;
        thisItem.GetComponent<Item>().itemType = currSelected.gameObject.GetComponentInParent<Item>().itemType;

        if (currSelected.gameObject.GetComponentInParent<Item>().itemType == Item.type.consumable)
        {
            this.GetComponent<CharacterItems>().Consumables.Add(thisItem.GetComponent<Item>());
            this.gameObject.GetComponent<CharacterItems>().useConsumable(thisItem.name);
        }
        else if (currSelected.gameObject.GetComponentInParent<Item>().itemType == Item.type.weapon)
        {
            this.GetComponent<CharacterItems>().Weapons.Add(thisItem.GetComponent<Item>());
            this.GetComponent<Combat>().AddDMG();
            this.GetComponent<MovementScript>().ChangeSpeed(thisItem.GetComponent<Item>().itemSpeed / speedEffect);
        }
        else if (currSelected.gameObject.GetComponentInParent<Item>().itemType == Item.type.armor)
        {
            this.GetComponent<CharacterItems>().Armor.Add(thisItem.GetComponent<Item>());
            this.GetComponent<Combat>().AddArmorHP();
            this.GetComponent<MovementScript>().ChangeSpeed(thisItem.GetComponent<Item>().itemSpeed /speedEffect);
        }
        Destroy(currSelected.transform.parent.gameObject);
        //Destroy(thisItem);
        currSelected = null;
    }
}
