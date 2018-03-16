using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float hitPoints = 100;
    public GameObject target;
    public float speed = 2;

    public void TakeDmg(float dmg)
    {
        hitPoints -= dmg;
    }

	void Update ()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        transform.Translate(horizontalMovement, 0, 0);
        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
