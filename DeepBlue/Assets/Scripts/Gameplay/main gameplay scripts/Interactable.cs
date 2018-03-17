using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    Renderer rn;
    void Start()
    {
        rn = this.GetComponentInParent<Renderer>();
    }

	public void Select()
    {
        rn.material.color = Color.red;
    }
    public void Deselect()
    {
        rn.material.color = Color.white;
    }
    public void WriteName()
    {
        Debug.Log(this.transform.parent.name);
    }
}
