using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelicula : MonoBehaviour
{
    public GameObject panel;
    public GameObject DeletePeli;
    private Animator animator;
    public Transform player;
    public Transform pelicula;
    public PeliPanel eliminar;
    public GameObject minijuego;
    public GameObject minijuegowin;
    //public AudioSource fuente;
    //public AudioClip clip;
    //private bool sonido = true;
    public bool activar = false;
    public float parts = 0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cerca();
        if (eliminar.eliminar)
        {
            this.DeletePeli.SetActive(false);
            this.panel.SetActive(false);
            parts = parts + 1f;

        }
        //Cerca2();
    }

    private void Cerca()
    {

        float restaX = Mathf.Abs(pelicula.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(pelicula.position.y - player.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
            if (Input.GetKey(KeyCode.E))
            {
                this.minijuego.SetActive(false);
                this.minijuegowin.SetActive(true);
                this.panel.SetActive(true);
                activar = true;
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }
    /**private void Cerca2()
    {

        float restaX = Mathf.Abs(senora.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(senora.position.y - player.transform.position.y);
        if (restaX < 2f && restaY < 3f)
        {
            animator.SetBool("cerca", true);
            if (Input.GetKey(KeyCode.E))
            {
                animator.SetBool("fin", true);
                if (sonido == true)
                {
                    fuente.Play();
                    sonido = false;
                }
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }**/
}
