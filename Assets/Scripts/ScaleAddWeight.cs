using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAddWeight : MonoBehaviour
{
    public bool heldInside = false;
    public bool removedByGrab = false;
    public bool restingOnScale = false;
    public float weightOnScale = 0f;

    private void OnTriggerEnter(Collider other)
    {
        removedByGrab = false;
        restingOnScale = false;
        heldInside = GetComponent<IsHeld>().isHeld;
        PutOnScale(other);
    }

    private void OnTriggerExit(Collider other)
    {
            RemovedFromScale(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (heldInside != GetComponent<IsHeld>().isHeld)
        {
            heldInside = !heldInside;
            if (heldInside)
            {
                removedByGrab = true;
                RemovedFromScale(other);
            }
            else
            {
                removedByGrab = false;
                PutOnScale(other);
            }
        }
    }

    private void PutOnScale(Collider other)
    {
        if (!GetComponent<IsHeld>().isHeld)
        {
            weightOnScale = GetComponent<Rigidbody>().mass;
            restingOnScale = true;
        }
    }


    private void RemovedFromScale(Collider other)
    {
        if (restingOnScale)
        {
            weightOnScale = 0f;
            restingOnScale = false;
            heldInside = false;
        }
    }
}
