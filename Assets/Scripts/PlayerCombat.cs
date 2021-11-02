using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{ 

    public Pigeon.Animator animator;

    Vector2 pos;

    public bool attack = false;
    private int attackCounter = 0;
    public int attackTime = 25;  

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage;

    public float attackRate = 2f;
    float nextAttackTime = 0f; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(gameObject.transform.position.x, transform.position.y);

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
        }


        if(attack == true)
        {
            attackCounter += 1;
            if (attackCounter >= attackTime)
            {
                attack = false;
                attackCounter = 0;
                
               
            }
        }
     
    }

    void Attack()
    {
        animator.Play(1);

        attack = true;

      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.TryGetComponent(out Enemy enemyScript))
            {
                enemyScript.TakeDamage(attackDamage); 
            }
            Debug.Log(enemy.name); 
        }



        //detect enemies in range of attack
        //damage them 
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return; 
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }

}
 