using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int Score = 0;
    [SerializeField] private Text ScoreText;
    public void TakeScore(int scoreCount)
    {
        Score += scoreCount;
        ScoreText.text = Score.ToString();
    }
}
