using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 100f;
    public float currentHP;
    
    void Start()
    {
        currentHP = hp;
    }
    
    public void TakePlayerDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        Destroy(gameObject);
    }
}
