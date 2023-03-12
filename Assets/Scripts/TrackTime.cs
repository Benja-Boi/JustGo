using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTime : MonoBehaviour
{
    public GameEventFloat reportNewResult;
    private bool isRunning = false;
    public float timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timePassed += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning= false;
        ReportResult(timePassed);
        ResetTimer();
    }

    public void ResetTimer()
    {
        timePassed = 0;
    }

    private void ReportResult(float result)
    {
        reportNewResult.Raise(result);
    }
}
