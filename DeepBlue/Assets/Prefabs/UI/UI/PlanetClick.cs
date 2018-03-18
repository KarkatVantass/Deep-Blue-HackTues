using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetClick : MonoBehaviour {

    private GameObject ship;
    public float speed = 10;
    public Transform target;
    private bool atDest = false;
    public Vector3 middle;
    private int sceneIndex;

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
                Debug.Log("mpx = " + this.transform.position.x + "tpx" + target.transform.position.x );
                 Debug.Log("mpy = " + this.transform.position.y + "tpy" + target.transform.position.y );

                ship.transform.position = Vector2.MoveTowards(ship.transform.position, target.transform.position, speed * Time.deltaTime);
                speed = Mathf.Lerp(speed, speed + 30, 0.07f);
            }
            else if (ship.transform.position == target.transform.position)
            {
                Debug.Log(sceneIndex);
                atDest = true;
                speed = 10;
                changeButtonInteraction(true);
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    public void planetClick(int index)
    {
        
        atDest = false; 
        this.ship = GameObject.Find("ship");
        this.target = gameObject.transform;
        this.middle = (ship.transform.position - target.transform.position) / 2;
        this.sceneIndex = index;

        
        changeButtonInteraction(false);
        
    }
    private void changeButtonInteraction(bool state)
    {
       // Debug.Log(sceneIndex);
        foreach (var i in FindObjectsOfType<Button>())
        {
            i.interactable = state;
        }
    }
}
