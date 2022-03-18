using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
