// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjects
{
    public class GameEventListenerFloat : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEventFloat Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<float> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(float value)
        {
            Response.Invoke(value);
        }
    }
}
