using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject prefab;
    public GameObject target;
    public float x=0, y=0;

	void Update () {
		if(target == null)
        {
            RespawnThis();
        }
	}
    void RespawnThis()
    {
        Vector3 respawnPos = new Vector3(x,y,0);
        target = Instantiate(prefab,respawnPos,Quaternion.identity);
    }
}
