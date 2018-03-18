using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
    
    Image rn;
    void Start()
    {
        rn = this.GetComponentInParent<Image>();
    }

	public void Select()
    {
        rn.color = Color.red;
    }
    public void Deselect()
    {
        rn.color = Color.white;
    }

    public void WriteName()
    {
        Debug.Log(this.transform.parent.name);
    }
}
