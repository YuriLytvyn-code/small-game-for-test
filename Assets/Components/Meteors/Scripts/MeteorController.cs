﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private float meteorHP = 200f;
    [SerializeField] private float currentHP = 0f;
    [SerializeField] private float meteorDamage = 100f;
    [SerializeField] private int Koef = 1;
    private Animator anim;
    void Start()
    {
        currentHP = meteorHP;
        anim = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            GameObject.FindWithTag("ScoreController").gameObject.GetComponent<ScoreSystem>().TakeScore(100 * Koef);
            DestroyAnim();
        }
    }

    public void DestroyAnim()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        anim.SetTrigger("Die");
        // if(gameObject.name.Equals("IronAsteroid")){GameObject.FindWithTag("ScoreController").gameObject.GetComponent<ScoreSystem>().TakeScore(100 * ironKoef);}
        // if(gameObject.name.Equals("GoldAsteroid")){GameObject.FindWithTag("ScoreController").gameObject.GetComponent<ScoreSystem>().TakeScore(100 * goldKoef);}
        // if(gameObject.name.Equals("DiamondAsteroid")){GameObject.FindWithTag("ScoreController").gameObject.GetComponent<ScoreSystem>().TakeScore(100 * diamondKoef);}
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return meteorDamage;
    }
}
