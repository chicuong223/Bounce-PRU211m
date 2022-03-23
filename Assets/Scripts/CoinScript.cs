using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    BallMovement ball;

    private void Start()
    {
        ball = BallMovement.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            ball.score += 1;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            //gameObject.GetComponent<AudioSource>().Play();
            //Debug.Log(ball.score);
            Destroy(gameObject);
        }
    }
}
