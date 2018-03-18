using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combat : MonoBehaviour {


    public float hitPoints = 100;
    public float totalHP;

    public float attackRange = 3;

    public float attackDmg = 30;
    public float TotalAD;

    public float cooldown = 1;

    float LastTime;

    void Start()
    {
        totalHP = hitPoints;
        LastTime = Time.time;
    }
    
	void Update ()
    {
        if (totalHP<=0)
        {
            Die();
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
            enemy.gameObject.GetComponent<Enemy>().TakeDmg(TotalAD);
        }
    }

    public void TakeDmg(float dmg)
    {
        totalHP -= dmg;
        hitPoints -= dmg;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void AddArmorHP()
    {
        totalHP = hitPoints;
        foreach(var armor in this.gameObject.GetComponent<CharacterItems>().Armor)
        {
            totalHP += armor.itemStrenght;
            this.gameObject.GetComponent<MovementScript>().ChangeSpeed(armor.itemSpeed);
        }
    }
    public void AddDMG()
    {
        TotalAD = attackDmg;
        foreach (var weapon in this.gameObject.GetComponent<CharacterItems>().Weapons)
        {
            TotalAD += weapon.itemStrenght;
        }
    }
}
