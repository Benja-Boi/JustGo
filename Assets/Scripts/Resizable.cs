using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resizable : MonoBehaviour, IResizable
{
    public float maxScale = 1;
    public float minScale = 2;

    private Transform trns;
    
    private void Start()
    {
        trns = GetComponent<Transform>();
    }

    public void Shrink(float amount)
    {
        Debug.Log("Amount= " + amount);
        Debug.Log("Old scale= " + trns.localScale.x);
        if (trns.localScale.x - amount > minScale)
        {
            Debug.Log("Expected scale= " + (trns.localScale.x - amount));
            trns.localScale -= amount * Vector3.one;
            Debug.Log("New scale= " + trns.localScale.x);
        }
    }
    
    public void Enlarge(float amount)
    {
        Debug.Log("old scale= " + trns.localScale.x);
        if (trns.localScale.x + amount < maxScale)
        {
            trns.localScale += amount * Vector3.one;
            Debug.Log("new scale= " + trns.localScale.x);
        }
    }
    
}
