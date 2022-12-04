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

    IEnumerator ResetScene()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(1f);

        // Cambias de escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
        StartCoroutine(ResetScene());
    }
    public void ButtonQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}

