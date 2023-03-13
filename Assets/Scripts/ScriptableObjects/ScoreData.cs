using System;
using System.Collections;
using System.Collections.Generic;
using CSharpObjects;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class ScoreData : ScriptableObject
    {
        public List<ScoreObject> scores = new List<ScoreObject>();

        public void RegisterScore(ScoreObject newScore)
        {
            scores.Add(newScore);
            scores.Sort((x, y) => x.TimeInSeconds.CompareTo(y.TimeInSeconds));
        }

        public string[] getHighScores(int numScores)
        {
            string[] results = new string[numScores];
            for (int i = 0; i < numScores; i++)
            {
                TimeSpan valueAsSpan = TimeSpan.FromSeconds(scores[i].TimeInSeconds);
                results[i] = scores[i].playerName + " : " + valueAsSpan.ToString(@"hh\:mm\:ss");
            }

            return results;
        }

        public void PrintScores()
        {
            foreach (ScoreObject score in scores)
            {
                Debug.Log(score.playerName + " : " + score.TimeInSeconds.ToString(@"hh\:mm\:ss"));
            }
        }
    }
}
