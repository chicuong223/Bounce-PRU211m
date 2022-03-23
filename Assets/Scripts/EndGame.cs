using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    Text lv1;
    Text lv2;
    Text lv3;
    Text lv4;
    Text score1;
    Text score2;
    Text score3;
    Text score4;
    Text lives;
    Text totalScore;
    // Start is called before the first frame update
    void Start()
    {
        lv1 = GameObject.Find("TextLevel1").GetComponent<Text>();
        lv2 = GameObject.Find("TextLevel2").GetComponent<Text>();
        lv3 = GameObject.Find("TextLevel3").GetComponent<Text>();
        lv4 = GameObject.Find("TextLevel4").GetComponent<Text>();
        score1 = GameObject.Find("ScoreLevel1").GetComponent<Text>();
        score2 = GameObject.Find("ScoreLevel2").GetComponent<Text>();
        score3 = GameObject.Find("ScoreLevel3").GetComponent<Text>();
        score4 = GameObject.Find("ScoreLevel4").GetComponent<Text>();
        lives = GameObject.Find("LivesCount").GetComponent<Text>();
        totalScore = GameObject.Find("TotalScore").GetComponent<Text>();

        lv1.text = $"Level 1\n{TimeSpan.FromSeconds(LoadLevel.times[0]).ToString("hh':'mm':'ss")}";
        lv2.text = $"Level 2\n{TimeSpan.FromSeconds(LoadLevel.times[1]).ToString("hh':'mm':'ss")}";
        lv3.text = $"Level 3\n{TimeSpan.FromSeconds(LoadLevel.times[2]).ToString("hh':'mm':'ss")}";
        lv4.text = $"Level 4\n{TimeSpan.FromSeconds(LoadLevel.times[3]).ToString("hh':'mm':'ss")}";

        score1.text = LoadLevel.scores[0].ToString();
        score2.text = LoadLevel.scores[1].ToString();
        score3.text = LoadLevel.scores[2].ToString();
        score4.text = LoadLevel.scores[3].ToString();

        lives.text = BallMovement.Lives.ToString();

        totalScore.text =
            $"{LoadLevel.scores[0]} + {LoadLevel.scores[1]} + {LoadLevel.scores[2]} + {LoadLevel.scores[3]} + 2 * {BallMovement.Lives} = {LoadLevel.scores[0] + LoadLevel.scores[1] + LoadLevel.scores[2] + LoadLevel.scores[3] + 2 * BallMovement.Lives}";
    }

    private void Awake()
    {

    }
}
