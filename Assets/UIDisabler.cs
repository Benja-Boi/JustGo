using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisabler : MonoBehaviour
{
    public List<GameObject> gos;

    public void DisableObjects()
    {
        foreach (GameObject go in gos)
        {
            go.SetActive(false);
        }
    }
    
    public void EnableObjects()
    {
        foreach (GameObject go in gos)
        {
            go.SetActive(true);
        }
    }
}
