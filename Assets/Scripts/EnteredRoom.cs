using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredRoom : MonoBehaviour
{
    public GameEvent roomEntered;
    public GameEvent roomLeft;
    private bool invoked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.localPosition.z >= 3f && !invoked)
        {
            invoked = true;
            StartCoroutine(WaitSeconds());
        }

        if(transform.localPosition.z <= 2.3 && invoked)
        {
            invoked = false;
            StartCoroutine(WaitSeconds());
        }
    }

    private IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3f);

        if (invoked)
        {
            roomEntered.Raise();
        }
        else
        {
            roomLeft.Raise();
        }
        
    }
}
