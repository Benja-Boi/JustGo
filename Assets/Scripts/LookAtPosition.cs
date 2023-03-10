using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class LookAtPosition : MonoBehaviour
{
    public Vector3Variable position;
    private Transform trns;

    private void Start()
    {
        trns = GetComponent<Transform>();
    }

    void Update()
    {
        trns.forward = (position.Value - transform.position).normalized;
    }
}
