using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDestroy : MonoBehaviour
{
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit, 25))
        {
            if(hit.transform.tag == "Destructible")
            {
                hit.transform.gameObject.GetComponent<grassShrink>().startShrink = true;
            }
        }
    }
}
