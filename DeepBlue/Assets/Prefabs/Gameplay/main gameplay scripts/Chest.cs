using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject character;
    public float interactionRadius = 5;
    MeshRenderer mr;

    void Start()
    {
        mr = this.GetComponentInChildren<MeshRenderer>();
    }

    void Update () {

        bool isInRange;
        if(character == null)
        {
            return;
        }
        if (
            character.transform.position.y < (this.transform.position.y + interactionRadius)
            && character.transform.position.y > (this.transform.position.y - interactionRadius)
            && character.transform.position.x < (this.transform.position.x + interactionRadius)
            && character.transform.position.x > (this.transform.position.x - interactionRadius)
            )
        {
            mr.material.color = Color.red;
            isInRange = true;
        }
        else
        {
            mr.material.color = Color.white;
            isInRange = false;
        }

        if(isInRange && Input.GetKeyDown("space"))
        {
            Debug.Log("i am wroking");
        }
	}
}
