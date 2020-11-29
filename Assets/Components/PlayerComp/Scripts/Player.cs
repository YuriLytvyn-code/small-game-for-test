using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 50f;
    public float stopSpeed = 0.9889f;
    public float rotSpeed = 60f;
    public float minusAngle = 90f;
    float ShootColldow = 0;
    public float fireDelay = 0.5f;
    public GameObject bullet; 
    public float playerHP = 100f;

    [SerializeField] private float currentHP;

    Rigidbody2D rb;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

        currentHP = playerHP;
    }
    
    void Update()
    {
        InputAxis();
        InputToStop();

        LookAtMouse();

        Shoot();
    }

    void FixedUpdate()
    {
        MovePlayer(movement);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(col.gameObject);
            TakeDamage(col.gameObject.GetComponent<EnemyBullet>().GetBulletDamage());
            Debug.Log("Shot!");


        }
    }

    void InputAxis()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void InputToStop()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StopPlayer(movement);
        }
    }

    void MovePlayer(Vector2 direction)
    {
        rb.AddForce(direction * moveForce * Time.deltaTime);
    }

    void StopPlayer(Vector2 direction)
    {
        rb.velocity *= stopSpeed;
    }

    void LookAtMouse()
    {
        Vector3 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - minusAngle;
        Quaternion desRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desRot, rotSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        ShootColldow -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && ShootColldow <= 0)
        {
            ShootColldow = fireDelay;
            
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
