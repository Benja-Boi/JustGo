using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTime : MonoBehaviour
{
    public GameEvent debugEvent;
    private bool enteredER = false;
    private float timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (enteredER)
        {
            timePassed += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.T))//debuging
        {
            Debug.Log(timePassed);
            debugEvent.Raise();
        }
    }

    public void TurnTimerOn()
    {
        enteredER = true;
    }

    public void TurnTimerOff()
    {
        enteredER= false;
    }
}
