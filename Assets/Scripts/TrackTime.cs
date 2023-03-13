using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTime : MonoBehaviour
{
    public GameEventFloat reportNewResult;
    public GameEventFloat reportResult1;
    public GameEventFloat reportResult2;
    public GameEventFloat reportResult3;
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

    public void ReportResultOne()
    {
        reportResult1.Raise(timePassed);
    }

    public void ReportResultTwo()
    {
        reportResult2.Raise(timePassed);
    }

    public void ReportResultThree()
    {
        reportResult3.Raise(timePassed);
    }
}
