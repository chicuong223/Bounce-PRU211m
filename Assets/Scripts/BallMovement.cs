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
    bool CanInflate = true;
    bool CanJump = true;
    float buttonTime = 0.3f;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    float cancelRate = 100;
    public static BallMovement Instance = null;
    public static int Lives = 3;

    [SerializeField]
    AudioClip jumpClip;
    [SerializeField]
    AudioClip inflateClip;
    [SerializeField]
    AudioClip deadClip;
    AudioSource audioSource;
    float deathHeight = -40f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanInflate = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        DeadFall();
    }

    void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var pos = transform.position;
        //if (h < 0)
        //{
        //    transform.Rotate(Vector3.forward * 300 * Time.deltaTime);
        //}
        //else if (h > 0) transform.Rotate(Vector3.back * 300 * Time.deltaTime);
        transform.Rotate(Vector3.forward * (-h) * 300 * Time.deltaTime);
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

    bool CheckSideCollision(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collider.bounds.center;

        bool top = contactPoint.y >= center.y;
        Debug.Log(top);
        return top;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump)
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
        if (collision.gameObject.tag.Equals("Killer"))
        {
            Kill();
        }
        else if (collision.gameObject.tag.Equals("Pumper"))
        {
            audioSource.clip = inflateClip;
            Inflate();
        }
        else if(collision.gameObject.tag.Equals("Deflate"))
        {
            Deflate();
        }
        else if (collision.gameObject.tag.Equals("Platform"))
        {
            var isTop = CheckSideCollision(collision);
            if(isTop)
            {
                audioSource.clip = jumpClip;
                CanJump = true;
            }
        }
        else
        {
            CanJump = false;
        }
        audioSource.Play();
    }

    private void Kill()
    {
        //Destroy(gameObject);
        Lives -= 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void DeadFall()
    {
        var pos = transform.position;
        if(pos.y <= deathHeight)
        {
            Kill();
        }
    }


    private void Inflate()
    {
        if (CanInflate)
        {
            var scale = transform.localScale;
            scale.x *= 2;
            scale.y *= 2;
            transform.localScale = scale;
            CanInflate = false;
            jumpForce *= 2;
        }
    }

    private void Deflate()
    {
        if(!CanInflate)
        {
            var scale = transform.localScale;
            scale.x /= 2;
            scale.y /= 2;
            transform.localScale = scale;
            CanInflate = true;
            jumpForce /= 2;
        }
    }

}
