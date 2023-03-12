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
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        public float Value;
        
        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }
    }
}



