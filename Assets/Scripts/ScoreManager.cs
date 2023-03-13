using System.Collections;
using System.Collections.Generic;
using CSharpObjects;
using ScriptableObjects;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreData sd;

    public void RegisterScore(float score)
    {
        Debug.Log("New Score: " + score);
        sd.RegisterScore(new ScoreObject(score, "Danny Seidner"));
        sd.PrintScores();
    }
}
