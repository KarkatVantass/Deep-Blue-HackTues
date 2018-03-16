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
        else
        {
            Debug.Log(Time.time);
            Debug.Log(LastTime);
        }
	}
    void Attack()
    {
        LastTime = Time.time;
        Debug.Log("attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, attackRange);
        foreach(var enemy in enemies.Where(x => x.gameObject.tag == "Enemy"))
        {
            GameObject target = enemy.gameObject;

            target.GetComponent<Enemy>().TakeDmg(attackDmg);
        }
    }
}
