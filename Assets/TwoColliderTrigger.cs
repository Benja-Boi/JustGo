using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoColliderTrigger : MonoBehaviour
{
    [SerializeField] private SimpleTrigger trigger1;
    [SerializeField] private SimpleTrigger trigger2;
    [SerializeField] private UnityEvent triggeredEvent;
    [SerializeField] private float triggerDelay = 1;
    private float timer;
    private bool timerRunning = false;

    private void Start()
    {
        timer = triggerDelay;
    }

    void Update()
    {
        if (timer <= 0)
        {
            triggeredEvent.Invoke();
        }

        if (timerRunning)
        {
            timer -= Time.deltaTime;
        }
        
        if (trigger1.isTriggered && trigger2.isTriggered)
        {
            timerRunning = true;
        }
        else
        {
            timerRunning = false;
            timer = triggerDelay;
        }
    }
}
