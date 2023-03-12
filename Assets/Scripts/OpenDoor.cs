using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool isOpening = false;
    private float timer = 0f;
    public float duration = 5f;
    private Quaternion origin;
    private Quaternion target;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.rotation;
        target = Quaternion.Euler(new Vector3(-90, -120, -120));
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.rotation = Quaternion.Lerp(origin, target, progress);
            if (progress >= 1)
            {
                isOpening = false;
            }
        }
    }

    public void ShouldOpen()
    {
        isOpening = true;
    }
}
