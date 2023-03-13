using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeightText : MonoBehaviour
{
    [SerializeField] private FloatVariable weight;
    [SerializeField] private Text txt;
    private float targetWeight = 13f;
    
    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        if (weight.Value != targetWeight)
        {
            txt.text = weight.Value + " IS NOT " + targetWeight + "!";
        }
    }
}
