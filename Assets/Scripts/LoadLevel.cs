using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    public static List<float> times = new List<float>();
    float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneName);
        times.Add(time);
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneName);
        BallMovement.Lives = 3;
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level1");
        BallMovement.Lives = 3;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
