using System;
using System.Collections;
using System.Collections.Generic;
using CSharpObjects;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    [Serializable]
    public class ScoreData : ScriptableObject
    {
        public List<ScoreObject> scores = new List<ScoreObject>();

        public void RegisterScore(ScoreObject newScore)
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
            foreach (ScoreObject score in scores)
            {
                Debug.Log(score.playerName + " : " + score.Value.ToString(@"hh\:mm\:ss"));
            }
        }
    }
}
