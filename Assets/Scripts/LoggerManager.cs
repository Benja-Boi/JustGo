using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoggerManager : MonoBehaviour
{
    TrialLogger tl;

    public string playerName = "PlayerUnknown";

    private float firstTaskTime = 0;
    private float secondTaskTime = 0;
    private float thirdTaskTime = 0;


    private void Start()
    {
        List<string> columnList = new List<string> {"Task #", "Task Time", "Time Passed", "Total Time" };

        tl = GetComponent<TrialLogger>();

        tl.Initialize(playerName, columnList);
    }

    public void LogTaskOne(float seconds)
    {
        tl.StartTrial();

        firstTaskTime = seconds;
        tl.trial["Task #"] = "Task 1";
        tl.trial["Task Time"] = TimeSpan.FromSeconds((double)new decimal(firstTaskTime)).ToString();
        tl.trial["Time Passed"] = TimeSpan.FromSeconds((double)new decimal(seconds)).ToString();
        tl.trial["Total Time"] = "";

        tl.EndTrial();
    }

    public void LogTaskTwo(float seconds)
    {
        tl.StartTrial();

        secondTaskTime = seconds - firstTaskTime;
        tl.trial["Task #"] = "Task 2";
        tl.trial["Task Time"] = TimeSpan.FromSeconds((double)new decimal(secondTaskTime)).ToString();
        tl.trial["Time Passed"] = TimeSpan.FromSeconds((double)new decimal(seconds)).ToString();
        tl.trial["Total Time"] = "";

        tl.EndTrial();
    }

    public void LogTaskThree(float seconds)
    {
        tl.StartTrial();

        thirdTaskTime = seconds - secondTaskTime - firstTaskTime;
        tl.trial["Task #"] = "Task 3";
        tl.trial["Task Time"] = TimeSpan.FromSeconds((double)new decimal(thirdTaskTime)).ToString();
        tl.trial["Time Passed"] = TimeSpan.FromSeconds((double)new decimal(seconds)).ToString();
        tl.trial["Total Time"] = "";

        tl.EndTrial();
    }

    public void LogEscaped(float seconds)
    {
        tl.StartTrial();

        tl.trial["Task #"] = "All";
        tl.trial["Task Time"] = "";
        tl.trial["Time Passed"] = "";
        tl.trial["Total Time"] = TimeSpan.FromSeconds((double)new decimal(seconds)).ToString();

        tl.EndTrial();
    }
}
