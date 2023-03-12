using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnEvent : MonoBehaviour
{
    private Collider[] _colliders;
    private Renderer _renderer;
    private Light _light;

    private void Start()
    {
        _colliders = GetComponents<Collider>();
        _renderer = GetComponent<Renderer>();
        _light = GetComponent<Light>();
    }

    public void Disable()
    {
        if (_colliders.Length != 0)
        {
            foreach (Collider c in _colliders)
                c.enabled = false;
        }

        if (_renderer != null)
        {
            _renderer.enabled = false;
        }
        
        if (_light != null)
        {
            _light.enabled = false;
        }
    }
}
