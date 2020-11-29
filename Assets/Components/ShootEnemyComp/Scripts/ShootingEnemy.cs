using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private float enemyRotSpeed = 150f;
    [SerializeField] private float minusAngle = 90;
    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float rayDistance = 15f;
    float ShootColldow = 0;
    Transform Player;
    Transform RayCastPos;

    void Start()
    {
        RayCastPos = gameObject.transform.GetChild(0).transform;
        //test
    }

    void Update()
    {
        LookAtPlayer();
        DelayToShoot();
        RayToPlayer();
    }

    void LookAtPlayer()
    {
        if(Player == null)
        {
            GameObject go = GameObject.Find("Player");
            if(go != null)
            {
                Player = go.transform;
            }
        }
        if(Player == null)
        {
            return;
        }

        Vector3 playerPos = Player.position - transform.position;
        Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - minusAngle;
        Quaternion desRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desRot, enemyRotSpeed * Time.deltaTime);
    
    }

    
    void DelayToShoot()
    {
        ShootColldow -= Time.deltaTime;
    }
    void Shoot()
    {
        ShootColldow = fireDelay;
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void RayToPlayer()
    {
        if(ShootColldow <= 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(RayCastPos.position, transform.TransformDirection(Vector2.up), rayDistance);
            if(hit)
            {
                if(hit.collider.tag.Equals("Player"))
                {
                    Shoot();
                }
                
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
