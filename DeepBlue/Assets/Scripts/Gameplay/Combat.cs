using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combat : MonoBehaviour {


    public float hitPoints = 100;
    public float attackRange = 3;
    public float attackDmg = 30;
    public float cooldown = 1;
    float LastTime;

    void Start()
    {
        LastTime = Time.time;
    }
    
	void Update ()
    {
        if (hitPoints<=0)
        {
            Destroy(this.gameObject);
        }
		if(Input.GetKeyDown("e") && (LastTime + cooldown <= Time.time))
        {
            Attack();
        }
	}
    void Attack()
    {
        LastTime = Time.time;
        Debug.Log("attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, attackRange);
        foreach(var enemy in enemies.Where(x => x.gameObject.tag == "Enemy"))
        {
            enemy.gameObject.GetComponent<Enemy>().TakeDmg(attackDmg);
        }
    }

    public void TakeDmg(float dmg)
    {
        hitPoints -= dmg;
    }
}
