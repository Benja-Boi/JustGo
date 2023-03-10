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
    private bool isSlidingOpen;
    private bool isSlidingClose;
    void Start()
    {
        origin = transform.position;
        target = origin + offset;
        timer = 0;
        isSlidingOpen = false;
        isSlidingClose = false;
    }

    private void Update()
    {
        if (isSlidingOpen)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.position = Vector3.Lerp(origin, target, progress);
            if (progress >= 1)
            {
                isSlidingOpen = false;
                timer = 0;
            }
        }

        if (isSlidingClose)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.position = Vector3.Lerp(target, origin, progress);
            if (progress >= 1)
            {
                isSlidingClose = false;
                timer = 0;
            }
        }

    }
    
    public void SlideOpen()
    {
        isSlidingOpen = true;
    }

    public void SlideClose()
    {
        isSlidingClose = true;
    }
}
