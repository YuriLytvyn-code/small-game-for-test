using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    public float lifeTime = 5f;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){Destroy(gameObject);}
    }
}
