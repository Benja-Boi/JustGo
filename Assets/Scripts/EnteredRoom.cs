using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredRoom : MonoBehaviour
{
    public GameEvent roomEntered;
    public GameEvent sliding;
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
    }

    private IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3f);

        sliding.Raise();
        roomEntered.Raise();
    }
}
