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
    public class Vector3Variable : ScriptableObject
    {
        public Vector3 Value;
        
        public void SetValue(Vector3 value)
        {
            Value = value;
        }

        public void SetValue(Vector3Variable value)
        {
            Value = value.Value;
        }
    }
}



