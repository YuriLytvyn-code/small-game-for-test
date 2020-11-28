using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SootingBody : MonoBehaviour
{
    [SerializeField] private float enemyHP = 100f;
    [SerializeField] private float currentHp;
    
    void Start()
    {
        currentHp = enemyHP;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Bullet"))
        {
            Debug.Log("hit!");
            Destroy(col.gameObject);
            TakeDamage(col.gameObject.GetComponent<Bullet>().GetBulletDamage());
        }
    }

    void TakeDamage(float damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
