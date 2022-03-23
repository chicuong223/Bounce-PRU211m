using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    public static List<float> times = new List<float>();
    BallMovement ball;
    public static List<int> scores = new List<int>();
    float time;

    private void Start()
    {
        ball = BallMovement.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Finish"))
        {
            SceneManager.LoadScene(SceneName);
            times.Add(time);
            scores.Add(ball.score);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneName);
        BallMovement.Lives = 50;
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level1");
        BallMovement.Lives = 50;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
