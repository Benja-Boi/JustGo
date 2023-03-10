using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitCheck : MonoBehaviour
{
    public GameEvent onRayCastHit;
    public LayerMask mask;
    private Transform trns;

    private void Start()
    {
        trns = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up,out hit,Mathf.Infinity,mask))
        {
            onRayCastHit.Raise();
        }
    }
}
