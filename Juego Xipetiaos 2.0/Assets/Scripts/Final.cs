using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Quit());
    }
    public void ButtonQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    IEnumerator Quit()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(114f);

        // Cambias de escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);

    }
}
