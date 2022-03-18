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
    bool jumpCancelled;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            jumpCancelled = false;
            CanJump = false;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
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
        }
        else
        {
            CanJump = false;
        }
    }
}
