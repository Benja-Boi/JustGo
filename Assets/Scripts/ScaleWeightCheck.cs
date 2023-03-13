using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWeightCheck : MonoBehaviour
{
    public GameEvent gameEvent;

    private float targetWeight = 13f;
    
    public float cube2Mass;
    public float cube3Mass;
    public float cube4Mass;
    public float cube5Mass;
    public float candleMass;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube 2")
        {
            cube2Mass = other.GetComponent<ScaleAddWeight>().weightOnScale;
        }
        if (other.name == "Cube 3")
        {
            cube3Mass = other.GetComponent<ScaleAddWeight>().weightOnScale;
        }
        if (other.name == "Cube 4")
        {
            cube4Mass = other.GetComponent<ScaleAddWeight>().weightOnScale;
        }
        if (other.name == "Cube 5")
        {
            cube5Mass = other.GetComponent<ScaleAddWeight>().weightOnScale;
        }
        if (other.name == "Candle Light")
        {
            candleMass = other.GetComponent<ScaleAddWeight>().weightOnScale;
        }
    }

    private void Update()
    {
        if ((cube2Mass + cube3Mass + cube4Mass + cube5Mass + candleMass) == targetWeight)
        {
            gameEvent.Raise();
        }
    }
}
