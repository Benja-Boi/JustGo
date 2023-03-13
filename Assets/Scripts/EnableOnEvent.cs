using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEvent : MonoBehaviour
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

    public void Enable()
    {
        if (_colliders.Length != 0)
        {
            foreach (Collider c in _colliders)
                c.enabled = true;
        }

        if (_renderer != null)
        {
            _renderer.enabled = true;
        }

        if (_light != null)
        {
            _light.enabled = true;
        }
    }
}
