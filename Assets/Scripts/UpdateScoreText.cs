using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    private Text txt;
    [SerializeField] private int number;
    [SerializeField] private ScoreData scoreData;
    
    void Awake()
    {
        txt = GetComponent<Text>();
    }

    public void UpdateText()
    {
        if (scoreData.scores.Count >= number)
        {
            TimeSpan score = TimeSpan.FromSeconds(scoreData.scores[number - 1].TimeInSeconds);
            string playerName = scoreData.scores[number - 1].playerName;
            txt.text = number + ". " + playerName + "   :   " + score.ToString(@"hh\:mm\:ss\:ff");
        }
        else
        {
            txt.text = number + ". -------------";
        }

    } 

}
