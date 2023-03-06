using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClip()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}
