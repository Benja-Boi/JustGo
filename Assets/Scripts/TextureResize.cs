using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureResize : MonoBehaviour
{
    public float scaleFactor = 1.0f;
    private Material material;
    
    
    void Start()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.y / scaleFactor);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged && Application.isEditor && !Application.isPlaying)
        {
            GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.y / scaleFactor);
            transform.hasChanged = false;
        }
    }
}
