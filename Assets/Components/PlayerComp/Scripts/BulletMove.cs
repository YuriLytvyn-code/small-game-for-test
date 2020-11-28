using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed = 5f;
    Vector3 movement;
    Vector3 pos;
    void Update()
    {
        pos = transform.position;
        movement = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        pos += transform.rotation * movement;
        transform.position = pos;
        
    }
}
