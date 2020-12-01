using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        { 
            Debug.Log("Is player");
            gameObject.GetComponentInParent<Shahid>().SetIsPlayer(true);
        }
    }

    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        { 
            Debug.Log("Not player");
            gameObject.GetComponentInParent<Shahid>().SetIsPlayer(false);
        }
    }
}
