using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHeld : MonoBehaviour
{
    public bool isHeld = false;
    
    public void Holding()
    {
        isHeld = true;
    }

    public void NotHolding()
    {
        isHeld = false;
    }
}
