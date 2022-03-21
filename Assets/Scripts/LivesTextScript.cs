using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextScript : MonoBehaviour
{
    Text livesText;
    BallMovement ball;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        ball = BallMovement.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lives: {BallMovement.Lives}";
    }
}
