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
            GetComponent<AudioSource>().volume -= Time.deltaTime * fadeRate;

            if(GetComponent<AudioSource>().volume < 0)
            {
                invoked = false;
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().volume = 0.75f;
            }
        }
    }

    public void FadeOut()
    {
        invoked = true;
    }

}
