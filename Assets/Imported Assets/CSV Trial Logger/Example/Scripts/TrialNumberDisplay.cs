using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class TrialNumberDisplay : MonoBehaviour {

    Text text;

	void Awake () {
        text = GetComponent<Text>();
	}
	
    // called after a trial ends
    public void UpdateTrialNumber(float seconds)
    {
        text.text = string.Format("Time Passed: {0}", TimeSpan.FromSeconds((double)(new decimal(seconds))).ToString());
    }
}
