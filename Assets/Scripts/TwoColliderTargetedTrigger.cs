using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoColliderTargetedTrigger : MonoBehaviour
{
    [SerializeField] private TargetedTrigger trigger1;
    [SerializeField] private TargetedTrigger trigger2;
    [SerializeField] private GameEvent triggeredEvent;
    [SerializeField] private float triggerDelay = 1;
    private float timer;
    private bool timerRunning = false;
    private bool invoked = false;

    private void Start()
    {
        timer = triggerDelay;
    }

    void Update()
    {
        if (!invoked)
        {
            if (timer <= 0)
            {
                triggeredEvent.Raise();
                invoked = true;
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
}
