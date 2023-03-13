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
    }
}
