using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using ScriptableObjects;

namespace CSharpObjects
{
    [Serializable]
    public class ScoreObject
    {
        public float TimeInSeconds;
        public string playerName;

        public ScoreObject(float timeInSeconds)
        {
            TimeInSeconds = timeInSeconds;
        }
    
        public ScoreObject(float timeInSeconds, string name)
        {
            TimeInSeconds = timeInSeconds;
            playerName = name;
        }
    
        public void SetValue(float value, string name)
        {
            TimeInSeconds = value;
            playerName = name;
        }

        public void SetValue(FloatVariable value, string name)
        {
            TimeInSeconds = value.Value;
            playerName = name;
        }
    } 
}






