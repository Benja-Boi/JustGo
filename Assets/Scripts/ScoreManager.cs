using System;
using System.Collections;
using System.Collections.Generic;
using CSharpObjects;
using ScriptableObjects;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreData sd;
    [SerializeField] private GameEvent onScoreRegistered;
    [SerializeField] private GameEvent onGameStarted;
    private void Start()
    {
        onGameStarted.Raise();
    }

    public void RegisterScore(float score)
    {
        Debug.Log("New Score: " + score);
        sd.RegisterScore(new ScoreObject(score, "PlayerUnkown"));
        onScoreRegistered.Raise();
    }
}
