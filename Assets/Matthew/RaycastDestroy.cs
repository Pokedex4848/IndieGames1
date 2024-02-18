using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDestroy : MonoBehaviour
{
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit, 4))
        {
            if(hit.transform.tag == "Destructible")
            {
                hit.transform.localScale -= Vector3.one * Time.deltaTime * 0.75f;
                hit.transform.GetComponent<BoxCollider>().size += Vector3.one * Time.deltaTime * 4;
            }
        }
    }
}
