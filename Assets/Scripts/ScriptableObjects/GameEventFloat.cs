using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu]
public class GameEventFloat : ScriptableObject
{
    private readonly List<GameEventListenerFloat> eventListeners = new List<GameEventListenerFloat>();

    public void Raise(float value)
    {
        Debug.Log(this.name + "Event raised");
        for(int i = eventListeners.Count -1; i >= 0; i--)
            eventListeners[i].OnEventRaised(value);
    }

    public void RegisterListener(GameEventListenerFloat listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerFloat listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
