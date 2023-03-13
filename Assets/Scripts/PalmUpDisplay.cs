using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmUpDisplay : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private float range;
    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        bool isInXRange = (rotation.x > 0 -range) && (rotation.x < 0 + range);
        bool isInZRange = (rotation.z > 90 - range) && (rotation.z < 90 + range);

        if (isInXRange && isInZRange)
        {
            hud.SetActive(true);
        } else
        {
            hud.SetActive(false);
        }
    }
}
