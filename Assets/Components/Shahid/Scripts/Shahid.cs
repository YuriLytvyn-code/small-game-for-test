using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shahid : MonoBehaviour
{
    private Transform Player;
    private bool isPlayer = false;
    private float minusAngle = 90;
    private bool alive = true;

    private Rigidbody2D rb;
    [SerializeField] private float damage = 100f;
    [SerializeField] private float enemyRotSpeed = 120f;
    [SerializeField] private float enemySpeed = 10f;

    [SerializeField] private float enemyHP = 50f;
    [SerializeField] private float currentHP;
    [SerializeField] private float radius = 8f;

    private Animator anim;
    Vector2 direction;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHP = enemyHP;
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        FindPlayer();
        if(isPlayer && alive)
        {
            LookAtPlayer();
            MoveToPlayer();
        }
        isPlayer = false;
    }

    void FindPlayer()
    {
        Collider2D[] col =  Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
        for(int i = 0; i < col.Length; i++)
        {
            if(col[i].gameObject.tag.Equals("Player"))
            {
                isPlayer = true;
            }
        }
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
        direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg - minusAngle;
        Quaternion desRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desRot, enemyRotSpeed * Time.deltaTime);
    
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

    void MoveToPlayer()
    {
        Vector3 pos = transform.position;
		
		Vector3 velocity = new Vector3(0, enemySpeed * Time.deltaTime, 0);
		
		pos += transform.rotation * velocity;

		transform.position = pos;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            DieAnim();
        }
    }
    public void DieAnim()
    {
        alive = false;
        anim.SetTrigger("Die");
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
