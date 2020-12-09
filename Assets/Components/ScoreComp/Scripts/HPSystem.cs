using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    [SerializeField] private float HP = 0;
    [SerializeField] private Text ScoreText;
    
    public void TakeHP(float HPcount)
    {
        if(HPcount < 0)
        {
            HPcount = 0;
        }
        HP = HPcount;
        ScoreText.text = HP.ToString();
    }
}
