using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocate : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void RelocateRerotate()
    {
        transform.SetPositionAndRotation(originalPosition, originalRotation);
    }
}
