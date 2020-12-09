using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SootingBody : MonoBehaviour
{
    [SerializeField] private float enemyHP = 100f;
    [SerializeField] private float currentHp;
    [SerializeField] private int scoreForKill = 3000;
    private Animator anim;
    
    void Start()
    {
        currentHp = enemyHP;
        anim = gameObject.GetComponent<Animator>();
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
            GameObject.FindWithTag("ScoreController").gameObject.GetComponent<ScoreSystem>().TakeScore(scoreForKill);
            DieAnim();
        }
    }
    void DieAnim()
    {
        gameObject.GetComponentInChildren<ShootingEnemy>().Die();
        anim.SetTrigger("death");
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
