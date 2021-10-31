using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{ 

    public Pigeon.Animator animator;

    Vector2 pos;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage; 

    Enemy script; 

    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<Enemy>(); 
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(gameObject.transform.position.x, transform.position.y);


       if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
     
     
    }

    void Attack()
    {

      animator.Play(1);
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            script.TakeDamage(attackDamage); 
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
 