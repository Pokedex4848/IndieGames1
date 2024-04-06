using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraConfines : MonoBehaviour
{
    float lowerBound = 2.4f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-.4f, Mathf.Clamp(transform.parent.position.y, lowerBound, 72), -10);

        if(transform.position.y > lowerBound)
        {
            lowerBound = transform.position.y;
        }

        if(transform.parent.position.y < lowerBound - 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}