using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 point1;
    private Vector3 point2;
    private float positionLerp;

    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        point1 = transform.GetChild(0).position;
        point2 = transform.GetChild(1).position;

        foreach(Transform t in transform)
        {
            if(t.name != "Platform")
            {
                t.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    void Update()
    {
        positionLerp = (Mathf.Sin(Time.time * speed) / 2) + 0.5f;

        transform.position = Vector3.Lerp(point1, point2, positionLerp);
    }
}
