using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Senora : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform senora;
    public AudioSource fuente;
    public AudioClip clip;
    public Pelicula pelicula;
    private bool sonido = true;
    public GameObject minijuego;
    public GameObject minijuegowin;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fuente.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        Cerca();
    }

    private void Cerca()
    {
        if (pelicula.parts == 1)
        {
            float restaX = Mathf.Abs(senora.position.x - player.transform.position.x);
            float restaY = Mathf.Abs(senora.position.y - player.transform.position.y);
            this.minijuego.SetActive(true);

            if (restaX < 1f && restaY < 1f)
            {
                animator.SetBool("cerca", true);
                if (Input.GetKey(KeyCode.E))
                {
                    animator.SetBool("fin", true);
                    if (sonido == true)
                    {
                        this.minijuego.SetActive(false);
                        this.minijuegowin.SetActive(true);
                        StartCoroutine(CambiarEscena());
                        fuente.Play();
                        sonido = false;
                    }
                }
            }
            else
            {
                animator.SetBool("cerca", false);
            }
        }
    }
    IEnumerator CambiarEscena()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
