using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject MainCharacter;
    
	void Update () {
        this.transform.position = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y, -10);	
	}
}
