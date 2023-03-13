// using UnityEngine;
//
// namespace ScriptableObjects
// {
//     [CreateAssetMenu]
//     public class IntVariable : ScriptableObject
//     {
//         public int value;
//     }
// }


using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    public class ScoreVariable
    {
        public TimeSpan Value;
        public string playerName;

        public ScoreVariable(float value)
        {
            Value = TimeSpan.FromSeconds(value);
        }
        
        public ScoreVariable(float value, string name)
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



