using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeOnTrigger : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private bool isEnlarge = true;
    private List<IResizable> itemsToResize;

    private void Start()
    {
        itemsToResize = new List<IResizable>();
    }

    private void LateUpdate()
    {
        foreach (IResizable item in itemsToResize)
        {
            if (isEnlarge)
            {
                Debug.Log("Enlarging Object");
                item.Enlarge(speed * Time.deltaTime);
            } else
            {
                Debug.Log("Shrinking Object");
                item.Shrink(speed * Time.deltaTime);
            }
        } 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object triggered");
        IResizable r;
        if (other.gameObject.TryGetComponent<IResizable>(out r))
        {
            itemsToResize.Add(r);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited");
        IResizable r;
        if (other.gameObject.TryGetComponent<IResizable>(out r))
        {
            itemsToResize.Remove(r);
        }
    }
}
