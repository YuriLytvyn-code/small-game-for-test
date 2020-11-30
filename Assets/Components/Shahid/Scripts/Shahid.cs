using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shahid : MonoBehaviour
{
    private Transform Player;
    private bool isPlayer = false;
    private float minusAngle = 90;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float enemyRotSpeed = 120f;
    [SerializeField] private float enemySpeed = 10f;

    [SerializeField] private float enemyHP = 50f;
    [SerializeField] private float currentHP;

    private Animator anim;
    Vector2 direction;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHP = enemyHP;
        anim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if(isPlayer)
        {
            LookAtPlayer();
            MoveToPlayer();
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

    public void SetIsPlayer(bool isPl)
    {
        isPlayer = isPl;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            DieAnim();
        }
    }
    void DieAnim()
    {
        anim.SetTrigger("Die");
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
