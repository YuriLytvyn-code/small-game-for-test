using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    private bool isPlayer = false;
    [SerializeField] private float radius = 8f;

    void Update()
    {
        Collider2D[] col =  Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
        for(int i = 0; i < col.Length; i++)
        {
            if(col[i].gameObject.tag.Equals("Player"))
            {
                isPlayer = true;
            }

            if(isPlayer == true)
            {
                gameObject.GetComponentInParent<Shahid>().SetIsPlayer(true);
                isPlayer = false;
            }
            else
            {
                gameObject.GetComponentInParent<Shahid>().SetIsPlayer(false);
            }
        }
    }


    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(col.gameObject.tag.Equals("Player"))
    //     { 
    //         Debug.Log("Is player");
    //         gameObject.GetComponentInParent<Shahid>().SetIsPlayer(true);
    //     }
    // }

    
    // void OnTriggerExit2D(Collider2D col)
    // {
    //     if(col.gameObject.tag.Equals("Player"))
    //     { 
    //         Debug.Log("Not player");
    //         gameObject.GetComponentInParent<Shahid>().SetIsPlayer(false);
    //     }
    // }
}
