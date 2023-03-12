using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class ScoreData : ScriptableObject
    {
        public List<ScoreVariable> scores = new List<ScoreVariable>();

        public void RegisterScore(ScoreVariable newScore)
        {
            scores.Add(newScore);
            scores.Sort((x, y) => x.Value.TotalSeconds.CompareTo(y.Value.TotalSeconds));
        }

        public string[] getHighScores(int numScores)
        {
            string[] results = new string[numScores];
            for (int i = 0; i < numScores; i++)
            {
                results[i] = scores[i].playerName + " : " + scores[i].Value.ToString(@"hh\:mm\:ss");
            }

            return results;
        }

        public void PrintScores()
        {
            foreach (ScoreVariable score in scores)
            {
                Debug.Log(score.playerName + " : " + score.Value.ToString(@"hh\:mm\:ss"));
            }
        }
    }
}
