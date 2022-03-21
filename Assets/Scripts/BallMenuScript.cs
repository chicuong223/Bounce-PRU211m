using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMenuScript : MonoBehaviour
{
    Rigidbody2D rb;
    private float JumpForce = 5;
    bool CanJump = true;
    float buttonTime = 0.3f;
    float jumpTime;
    bool jumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }
    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Jump", 5, 0.25f);
    }

    void Jump()
    {
        if (CanJump)
        {
            float jumpAmount
                = Mathf.Sqrt(JumpForce * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpAmount), ForceMode2D.Impulse);
            jumping = true;
            jumpTime = 0;
            CanJump = false;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            CanJump = true;
            Jump();
        }
        else
        {
            CanJump = false;
        }
    }
}
