using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private float meteorHP = 200f;
    [SerializeField] private float currentHP = 0f;
    [SerializeField] private float meteorDamage = 100f;

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
            DestroyAnim();
        }
    }

    void DestroyAnim()
    {
        anim.SetTrigger("Die");
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
