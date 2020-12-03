using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    Transform player;
    [SerializeField] Vector3 offset;

    void Awake()
    {
        player = GameObject.Find("Player").gameObject.transform;
    }

    void Update()
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
    }
}
