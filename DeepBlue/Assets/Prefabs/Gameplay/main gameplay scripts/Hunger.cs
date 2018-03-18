using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour {
    public float hunger = 100;
    public float hungerDecreasePerSec = 1 / 3f;

    void Start()
    {
        InvokeRepeating("takeHunger",0,1);
    }
    void Update()
    {
        if(hunger < 0)
        {
            this.gameObject.GetComponent<Combat>().Die();
        }
    }
    void takeHunger()
    {
        hunger -= hungerDecreasePerSec;
    }
}
