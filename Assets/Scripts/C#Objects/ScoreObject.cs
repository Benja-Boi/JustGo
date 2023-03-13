using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using ScriptableObjects;

namespace CSharpObjects
{
    public class ScoreObject
    {
        public TimeSpan Value;
        public string playerName;

        public ScoreObject(float value)
        {
            Value = TimeSpan.FromSeconds(value);
        }
    
        public ScoreObject(float value, string name)
        {
            Value = TimeSpan.FromSeconds(value);
            playerName = name;
        }
    
        public void SetValue(float value, string name)
        {
            Value = TimeSpan.FromSeconds(value);
            playerName = name;
        }

        public void SetValue(FloatVariable value, string name)
        {
            Value = TimeSpan.FromSeconds(value.Value);
            playerName = name;
        }
    } 
}






