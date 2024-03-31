using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassShrink : MonoBehaviour
{
    public bool startShrink;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startShrink)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * 0.75f;
            transform.position -= Vector3.up * Time.deltaTime * 0.4f;
            transform.GetComponent<BoxCollider>().size += Vector3.one * Time.deltaTime * 4;
            if (Vector3.Distance(new Vector3(), transform.localScale) < 0.4f)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
