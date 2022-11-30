using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(ChangeScene());

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Esta es tu corutine
    IEnumerator ChangeScene()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(1f);

        // Cambias de escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
