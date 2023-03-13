using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFadeOut : MonoBehaviour
{
    private bool invoked = false;
    public float fadeRate;

    void Update()
    {
        if (invoked)
        {
            if (GetComponent<AudioSource>().volume > 0)
            {
                GetComponent<AudioSource>().volume -= Time.deltaTime * fadeRate;
            }
            
            if(GetComponent<AudioSource>().volume <= 0)
            {
                
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().volume = 0.75f;
                invoked = false;
            }
        }
    }

    public void FadeOut()
    {
        invoked = true;
    }

}
