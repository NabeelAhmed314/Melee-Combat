using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCombat : MonoBehaviour
{
    private FixedButton1 attackbtn;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;


    // Start is called before the first frame update
    void Start()
    {
        attackbtn = FindObjectsOfType<FixedButton1>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (attackbtn.Pressed)
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
        Collider2D[] enemies =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);
        Debug.Log(enemies);
        foreach(Collider2D enemy in enemies) 
        {
            Target target = enemy.GetComponent<Target>();
            target.takeDamage(10f);
        }
    }
}
