using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour {

    public float hitPoints = 100;
    public GameObject target;
    public float attackRadius = 5;
    public float speed = 1.7f;
    bool isSelectedTarget = false;

    public float attackRange = 3;
    public float attackDmg = 30;
    public float cooldown = 1;
    float LastTime;

    public void TakeDmg(float dmg)
    {
        hitPoints -= dmg;
    }

    void Start()
    {
        LastTime = Time.time;
    }

    void Update ()
    {
        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }

        if(target == null)
        {
            isSelectedTarget = false;
        }

        if (!isSelectedTarget)
        {
            SearchTarget();
        }
        else
        {
            Follow();
            if(IsInRange() && (LastTime + cooldown <= Time.time))
            {
                Attack();
            }
        }
    }
    void SearchTarget()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(this.transform.position, attackRadius);
        foreach (var targets in objects.Where(x => x.gameObject.tag == "Player"))
        {
            Debug.Log(targets);
            target = targets.gameObject;
            isSelectedTarget = true;
            return;
        }
    }

    void Follow()
    {
        var moveto = target.transform.position - this.transform.position;

        var movementVector = moveto * Time.deltaTime ;
        Debug.Log(movementVector);
        transform.Translate(movementVector);
    }
    bool IsInRange()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, attackRadius);
        foreach (var enemy in enemies.Where(x => x.gameObject.tag == "Player"))
        {
            return true;
        }
        return false;
    }
    void Attack()
    {
        LastTime = Time.time;
        //Debug.Log("attack");
        Collider2D[] players = Physics2D.OverlapCircleAll(this.transform.position, attackRange);
        foreach (var player in players.Where(x => x.gameObject.tag == "Player"))
        {
            player.gameObject.GetComponent<Combat>().TakeDmg(attackDmg);
        }
        
    }
}
