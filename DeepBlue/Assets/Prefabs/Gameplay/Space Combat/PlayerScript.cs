using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Enemy;

    public int hitPoints = 100;
    public int resistence = 0;

    public int dmg = 15;
    public int heal = 15;
    public int shield = 15;
    
    public void DoTurn()
    {
        Enemy.GetComponent<EnemyScript>().DoTurn();
    }
    void Attack()
    {
        Enemy.GetComponent<EnemyScript>().resistence -= dmg;
        Enemy.GetComponent<EnemyScript>().hitPoints -= Enemy.GetComponent<EnemyScript>().resistence;
        Enemy.GetComponent<EnemyScript>().resistence = 0;
    }
    void Heal()
    {
        hitPoints += heal;
        if(hitPoints > 100)
        {
            hitPoints = 100;
        }
    }
    void Defence()
    {
        resistence += shield;
    }
}
