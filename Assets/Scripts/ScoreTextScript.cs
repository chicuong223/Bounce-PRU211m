using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text scoreText;
    BallMovement ball;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        ball = BallMovement.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {ball.score}";
        Debug.Log(ball.score);

    }
}
