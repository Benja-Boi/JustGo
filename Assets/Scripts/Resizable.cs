using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        if (trns.localScale.x - amount > minScale)
        {
            trns.localScale -= amount * Vector3.one;
            PatchGrabbableScale(trns.localScale);
        }
    }

    public void Enlarge(float amount)
    {
        if (trns.localScale.x + amount < maxScale)
        {
            trns.localScale += amount * Vector3.one;
            PatchGrabbableScale(trns.localScale);
        }
    }

    public void PatchGrabbableScale(Vector3 val)
    {
        XRGrabInteractable cmp = GetComponent<XRGrabInteractable>();
        System.Reflection.FieldInfo field = cmp.GetType().GetField("m_TargetLocalScale", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        field.SetValue(cmp, val);
    }

}
