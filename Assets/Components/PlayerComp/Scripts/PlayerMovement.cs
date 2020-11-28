using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 50f;
    public float stopSpeed = 0.9889f;
    Rigidbody2D rb;
    Vector2 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKey(KeyCode.Space))
        {
            stopPlayer(movement);
        }
    }

    void FixedUpdate()
    {
        movePlayer(movement);
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     stopPlayer(movement);
        // }
    }

    void movePlayer(Vector2 direction)
    {
        rb.AddForce(direction * moveForce * Time.deltaTime);
    }

    void stopPlayer(Vector2 direction)
    {
        rb.velocity *= stopSpeed;
    }
}
