using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    public bool isTriggered = false;

    public void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
    }

    public void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
