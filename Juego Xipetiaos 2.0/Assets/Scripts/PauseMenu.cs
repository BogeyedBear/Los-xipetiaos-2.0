using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject pauseButton;
    public bool animacionNull = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            this.pauseMenu.SetActive(true);
            animacionNull = false;
        }
    }
    public void ButtonBack()
    {
        Time.timeScale = 1f;
        this.pauseMenu.SetActive(false);
        animacionNull = true;
    }
    public void ButtonReset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ButtonQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

