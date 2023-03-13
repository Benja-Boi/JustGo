using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedTrigger : MonoBehaviour
{
    public bool isTriggered = false;
    public string otherName;
    public float minScale;
    public float maxScale;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == otherName && other.transform.localScale.x >= minScale && other.transform.localScale.x <= maxScale)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == otherName)
        {
            isTriggered = false;
        }
    }
}
