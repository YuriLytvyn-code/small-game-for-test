using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    
    public float distance = 0;
    public float parallaxEffectAmount = 0;

    private Transform player;
    private float parallaxSpeed;

    private Vector2 playerOldPosition;

    void Start() {
        transform.localScale *= distance / 100f;
        parallaxSpeed = parallaxEffectAmount * 1000f / distance;

        player = GameObject.Find("Player").transform;
    }

    void Update() {
        
        Vector2 playerMovementVector = (Vector2)player.position - playerOldPosition;

        if (playerMovementVector.magnitude > 0.1f) {
            transform.position -= (Vector3)playerMovementVector * parallaxSpeed * Time.deltaTime;
        }

        playerOldPosition = player.position;
    }


}
