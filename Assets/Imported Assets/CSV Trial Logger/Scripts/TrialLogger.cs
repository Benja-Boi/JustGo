﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TrialLogger : MonoBehaviour {

    //private float seconds = 0f;
    //public string timePassed = TimeSpan.FromSeconds((double)new decimal(0f)).ToString();
    List<string> header;
    [HideInInspector]
    public Dictionary<string, string> trial;
    [HideInInspector]
    public string outputFolder;

    bool trialStarted = false;
    string playerName;
    string dataOutputPath;
    List<string> output;

    
    // Use this for initialization
    void Awake () {
        outputFolder = Application.dataPath + "/StreamingAssets" + "/output";
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }
    }
	

	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(string participantID, List<string> customHeader)
    {
        playerName = participantID;
        header = customHeader;
        InitHeader();
        InitDict();
        output = new List<string>();
        output.Add(string.Join(",", header.ToArray()));
        dataOutputPath = outputFolder + "/" + participantID + ".csv";
    }

    private void InitHeader()
    {
        header.Insert(0, "Player");
    }

    private void InitDict()
    {
        trial = new Dictionary<string, string>();
        foreach (string value in header)
        {
            trial.Add(value, "");
        }
    }

    public void StartTrial()
    {
        trialStarted = true;
        //seconds += 1;
        InitDict();
        trial["Player"] = playerName;
    }

    public void EndTrial()
    {
        if (output != null && dataOutputPath != null)
        {
            if (trialStarted)
            {
                //trial["end_time"] = Time.time.ToString();
                output.Add(FormatTrialData());
                trialStarted = false;
            }
            else Debug.LogError("Error ending trial - Trial wasn't started properly");

        }
        else Debug.LogError("Error ending trial - TrialLogger was not initialsed properly");
     

    }

    private string FormatTrialData()
    {
        List<string> rowData = new List<string>();
        foreach (string value in header)
        {
            rowData.Add(trial[value]);
        }
        return string.Join(",", rowData.ToArray());
    }

    private void OnApplicationQuit()
    {

        if (output != null && dataOutputPath != null)
        {
            File.WriteAllLines(dataOutputPath, output.ToArray());
            Debug.Log(string.Format("Saved data to {0}.", dataOutputPath));
        }
        else Debug.LogError("Error saving data - TrialLogger was not initialsed properly");
        
    }
}
