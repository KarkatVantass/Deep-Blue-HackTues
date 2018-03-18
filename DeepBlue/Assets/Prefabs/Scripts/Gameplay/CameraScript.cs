using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript: MonoBehaviour {

    public GameObject MainCharacter;
    
	void Update () {
        this.gameObject.transform.position = new Vector3(MainCharacter.transform.position.x, 14.5f, -37.8f);	
	}
}
