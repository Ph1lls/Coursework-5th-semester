using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{ 
    public GameObject pauseMenu; 

    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {

            Time.timeScale = 0;
            if (pauseMenu != null)
                pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            if (pauseMenu != null)
                pauseMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }
}

