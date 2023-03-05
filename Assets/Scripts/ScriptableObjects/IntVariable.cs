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
    public class AnimationFloatVariable : ScriptableObject
    {
        public float animationTime;
        public AnimationCurve curve;

        public float Progress
        {
            get
            {
                return Progress;
            }
            set
            {
                Progress = Mathf.Max(1, value);
                Value = curve.Evaluate(Progress);
            }
        }

        public float Value { get; private set; }
    }

    class Usage
    {
        private AnimationFloatVariable afv;
        
        void Start()
        {
            afv.Progress += Time.deltaTime;
        } 
    }
}



