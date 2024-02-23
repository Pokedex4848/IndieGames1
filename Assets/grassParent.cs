using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassParent : MonoBehaviour
{
    public GameObject[] grassGroup;
    public GameObject toyObject;
    

    // Update is called once per frame
    void Update()
    {
        float grassScale = 0;
        foreach (GameObject t in grassGroup)
        {
            if (t == null)
            {
                grassScale += 1f / ((float)grassGroup.Length);
            }
        }
        toyObject.transform.localScale = new Vector3(grassScale, grassScale, grassScale);
        if (grassScale.ToString() == "1")
        {
            toyObject.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
