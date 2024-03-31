using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerTwo : MonoBehaviour
{
    private float maxSpeed = 5;
    private float speed = 25;
    private float jumpForce;
    private float maxJumpForce = 500;
    private int maxJumps = 1;
    private int jumps;
    private float xScale;
    private float xRaw, yRaw;
    private bool dash = false;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    [SerializeField]
    private LayerMask player;

    [SerializeField]
    private LayerMask movingPlatform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xScale = Input.GetAxis("Horizontal");
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            jumpForce = maxJumpForce - (rb.velocity.y * 50);

            rb.AddForce(Vector2.up * jumpForce);
            jumps--;
        }

        if(isGrounded())
        {
            jumps = maxJumps;
            dash = true;
        }
        else
        {
            if(dash && Input.GetKeyDown(KeyCode.LeftShift) && (xRaw != 0 || yRaw != 0))
            {
                rb.velocity = new Vector2(xRaw, yRaw) * 10;
                dash = false;
            }
        }
    }

    void FixedUpdate()
    {
        if(Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(Vector2.right * xScale * speed);
        }
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.1f, ~player);
    }

    public bool onPlatform()
    {
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x / 2, bc.bounds.size.y), 0, Vector2.down, 0.1f, movingPlatform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Used to fix player stopping for a couple frames when they hit the ground
        if (isGrounded() && !onPlatform())
        {
            rb.AddForce(Vector2.right * xScale * 200);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(onPlatform())
        {
            transform.parent = collision.transform.parent;
        }
        else
        {
            transform.parent = null;
        }
    }
}