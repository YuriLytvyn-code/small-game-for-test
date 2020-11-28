using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    float ShootColldow = 0;
    public float fireDelay = 0.5f;

    public GameObject bullet; 
    void Update()
    {
        ShootColldow -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && ShootColldow <= 0)
        {
            Debug.Log("Pey!");
            ShootColldow = fireDelay;
            
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }
}
