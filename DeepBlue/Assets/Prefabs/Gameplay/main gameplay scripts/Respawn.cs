using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject prefab;
    public GameObject target;
    public float x=0, y=0,z=3;

    void Start()
    {
        Destroy(target);
        Vector3 respawnPos = new Vector3(x, y, z);
        target = Instantiate(prefab, respawnPos, Quaternion.identity);
    }

	void Update () {
		if(target == null)
        {
            RespawnThis();
        }
	}
    void RespawnThis()
    {
        Vector3 respawnPos = new Vector3(x,y,z);
        target = Instantiate(prefab,respawnPos,Quaternion.identity);
    }
}
