using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeliPanel : MonoBehaviour
{
    public bool eliminar = false;
    public GameObject regresar;
    public Pelicula active;
    public MenuTutorial menuNull;
    public AudioSource fuente;
    public AudioClip clip;
    public GameObject controles;

    // Start is called before the first frame update
    void Awake()
    {
        fuente.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (active.activar)
        {
            active.activar = false;
            Time.timeScale = 0f;
            menuNull.animacionNull = false;
            this.controles.SetActive(false);
        }
    }

    public void Borrar()
    {
        eliminar = true;
        menuNull.animacionNull = true;
        this.controles.SetActive(true);
        fuente.Play();
        Time.timeScale = 1f;
        //this.regresar.SetActive(false);
    }
}
