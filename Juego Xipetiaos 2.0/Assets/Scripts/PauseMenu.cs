using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject pauseButton;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            this.pauseMenu.SetActive(true);
        }
    }
    public void ButtonBack()
    {
        Time.timeScale = 1f;
        this.pauseMenu.SetActive(false);
    }
}

