using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInteractable : MonoBehaviour {

    public float interactionRange = 3;
    Collider currSelected = null;

	void Update ()
    {
        Find();
        if(Input.GetKeyDown("space") && currSelected != null)
        {
            Interact();
        }
	}
    void Find()
    {
        bool isFound = false;
        Collider[] obj = Physics.OverlapSphere(this.transform.position, interactionRange);
        foreach (var inter in obj.Where(x => x.gameObject.transform.parent.tag == "Interactable"))
        {
            if (currSelected != inter && currSelected != null)
            {
                currSelected.GetComponentInParent<Interactable>().Deselect();
            }
            currSelected = inter;
            currSelected.GetComponentInParent<Interactable>().Select();
            isFound = true;
            break;
        }
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
        currSelected.GetComponentInParent<Interactable>().WriteName();
    }
}
