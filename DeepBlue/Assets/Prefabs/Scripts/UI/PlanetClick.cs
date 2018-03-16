using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClick : MonoBehaviour {

    private GameObject ship;
    public float speed;
    public Transform target;
    private bool atDest = false;

    void Update()
    {
        if (ship.transform.position != target.transform.position && atDest == false)
        {
            ship.transform.position = Vector2.MoveTowards(ship.transform.position, target.transform.position, 30*Time.deltaTime);
        }else if(ship.transform.position != target.transform.position)
        {
            atDest = true;
        }
    }

    public void planetClick(int index)
    {
        atDest = false;
        this.ship = GameObject.Find("ship");
        this.target = gameObject.transform;
    }
}
