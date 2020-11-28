﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 10f;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] public float lifeTime = 5f;
    Vector3 movement;
    Vector3 pos;
    void Update()
    {
        Move();

        Die();
    }

    void Move()
    {
        pos = transform.position;
        movement = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        pos += transform.rotation * movement;
        transform.position = pos;
    }

    void Die()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){Destroy(gameObject);}
    }
}
