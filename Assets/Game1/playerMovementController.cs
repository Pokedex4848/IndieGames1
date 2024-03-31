using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementController : MonoBehaviour
{
    public GameObject camera;
    float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float yVel = GetComponent<Rigidbody>().velocity.y;
        camera.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        GetComponent<Rigidbody>().velocity = (Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right) * 10;
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        vel.y = yVel;
        GetComponent<Rigidbody>().velocity = vel;
    }
}
