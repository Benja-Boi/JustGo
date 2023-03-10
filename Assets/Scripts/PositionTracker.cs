using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public Vector3Variable position;

    private void Update()
    {
        position.Value = transform.position;
    }
}
