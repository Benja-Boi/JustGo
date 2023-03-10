using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReplacer : MonoBehaviour
{
    public string s1 = "";
    public string s2 = "";
    
    private Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
        txt.text = s1;
    }

    public void SetText1()
    {
        txt.text = s1;
    }
    
    public void SetText2()
    {
        txt.text = s2;
    }

}
