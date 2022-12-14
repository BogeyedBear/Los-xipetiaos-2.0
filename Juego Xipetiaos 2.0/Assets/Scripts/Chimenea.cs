using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimenea : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform chimenea;
    public GameObject pieza;
    public GameObject minijuego;
    public GameObject minijuegowin;
    public AudioSource fuente;
    public AudioClip clip;
    private bool sonido = true;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        fuente.clip = clip;
    }   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cerca();
    }
    private void Cerca()
    {

        float restaX = Mathf.Abs(chimenea.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(chimenea.position.y - player.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
            if (Input.GetKey(KeyCode.E))
            {
                this.pieza.SetActive(true);
                animator.SetBool("fin", true);
                this.minijuego.SetActive(false);
                this.minijuegowin.SetActive(true);
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
    }
}
