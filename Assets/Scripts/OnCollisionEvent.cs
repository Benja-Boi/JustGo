using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnCollisionEvent : MonoBehaviour
{
    public GameEvent gameEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameEvent != null && !collision.gameObject.CompareTag("Ring"))
        {
            gameEvent.Raise();
            Debug.Log("Collision occured");
        }
    }
}
