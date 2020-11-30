using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    [SerializeField] private float rad = 8f;
    Collider2D[] foundedCol;

    private bool isPlayer = false;

    void Update()
    {
        foundedCol = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), rad);
        FindPlayer();
    }    

    void FindPlayer()
    {
        for(int i = 0; i < foundedCol.Length; i++)
        {
            if(foundedCol[i].gameObject.tag.Equals("Player"))
            {
                isPlayer = true;
            }
        }
        if(isPlayer == true)
        {
            gameObject.GetComponentInParent<Shahid>().SetIsPlayer(true);
        }
        else
        {
            gameObject.GetComponentInParent<Shahid>().SetIsPlayer(false);
            isPlayer = false;
        }
    }
}
