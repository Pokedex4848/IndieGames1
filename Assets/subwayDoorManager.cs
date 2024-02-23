using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subwayDoorManager : MonoBehaviour
{
    public GameObject[] nullChecker;
    

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in nullChecker)
        {
            if (g != null)
                return;
        }
        Destroy(gameObject);
    }
}
