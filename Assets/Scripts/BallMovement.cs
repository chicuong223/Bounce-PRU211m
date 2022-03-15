using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 10f;
    Rigidbody2D rb;
    bool CanInflate = false;
    bool CanJump = true;
    float gravityScale = 10;
    float fallingGravityScale = 40;
    float buttonTime = 0.3f;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    float cancelRate = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanInflate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Move();
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CanJump)
            {
                float jumpAmount
                    = Mathf.Sqrt(jumpForce * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpAmount), ForceMode2D.Impulse);
                jumping = true;
                jumpTime = 0;
                jumpCancelled = false;
                CanJump = false;
            }
        }
        if(jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if(jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Killer"))
        {
            Kill();
        }
        if(collision.gameObject.tag.Equals("Pumper"))
        {
            Inflate();
        }
        if(collision.gameObject.tag.Equals("Platform"))
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if(gameObject != null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private void Inflate()
    {
        if(CanInflate)
        {
            var scale = transform.localScale;
            scale.x *= 2;
            scale.y *= 2;
            transform.localScale = scale;
            CanInflate = false;
            jumpForce *= 2;
        }

    }

}
