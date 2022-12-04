using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaPanel : MonoBehaviour
{
    public bool animacionNull = true;
    public AudioSource fuente;
    public AudioClip clip;
    // Start is called before the first frame update

    void Awake()
    {
        fuente.clip = clip;
    }

    // Update is called once per frame
   void Update()
    {
        Time.timeScale = 0f;
        fuente.Play();
        animacionNull = false;
    }
    public void ButtonSiguiente()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
