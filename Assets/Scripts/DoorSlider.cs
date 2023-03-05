using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlider : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 offset;
    public float duration = 2;
    private Vector3 target;
    private float timer;
    private bool isSliding;
    void Start()
    {
        origin = transform.position;
        target = origin + offset;
        timer = 0;
        isSliding = false;
    }

    private void Update()
    {
        if (isSliding)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.position = Vector3.Lerp(origin, target, progress);
            if (progress >= 1)
            {
                isSliding = false;
            }
        }

    }
    
    public void Slide()
    {
        isSliding = true;
    }
}
