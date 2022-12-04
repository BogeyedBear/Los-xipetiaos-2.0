using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTutorial : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject pauseButton;
    public GameObject controles;
    public bool animacionNull = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            this.pauseMenu.SetActive(true);
            this.controles.SetActive(false);
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
        this.controles.SetActive(true);
        animacionNull = true;
    }
    public void ButtonQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void ButtonSaltar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
