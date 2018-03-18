using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject Player;

    public int maxHitPoints = 100;
    public int hitPoints = 100;
    public int resistence = 0;

    public int dmg = 15;
    public int heal = 15;
    public int shield = 15;

    public bool isYourTurn = true;
    public void DoTurn()
    {
        if (hitPoints < 10)
        {
            Heal();
        }
        else
        {
            Attack();
        }
        Player.GetComponent<PlayerScript>().DoTurn();
    }

    void Attack()
    {
        Player.gameObject.GetComponent<PlayerScript>().resistence -= dmg;
        Player.gameObject.GetComponent<PlayerScript>().hitPoints -= Player.gameObject.GetComponent<PlayerScript>().resistence;
        Player.gameObject.GetComponent<PlayerScript>().resistence = 0;
    }
    void Heal()
    {
        hitPoints += heal;
        if (hitPoints > 100)
        {
            hitPoints = 100;
        }
    }
    void Defence()
    {
        resistence += shield;
    }
}
