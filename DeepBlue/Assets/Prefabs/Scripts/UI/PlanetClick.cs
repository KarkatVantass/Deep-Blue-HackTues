using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClick : MonoBehaviour {

    private GameObject ship;
    public float speed = 10;
    public Transform target;
    private bool atDest = false;
    public Vector3 middle;

    public void Start()
    {
        this.atDest = true;
    }

    void Update()
    {
        if (atDest == false)
        {
            if (ship.transform.position != target.transform.position)
            {

                ship.transform.position = Vector2.MoveTowards(ship.transform.position, target.transform.position, speed * Time.deltaTime);
                speed = Mathf.Lerp(speed, speed + 30, 0.07f);
            }
            else if (ship.transform.position == target.transform.position)
            {
                atDest = true;
                speed = 10;
            }
        }
    }

    public void planetClick(int index)
    {
        atDest = false;
        this.ship = GameObject.Find("ship");
        this.target = gameObject.transform;
        this.middle = (ship.transform.position - target.transform.position) / 2;
    }
}
