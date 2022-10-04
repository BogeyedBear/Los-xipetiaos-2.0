using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidadPlayer = 0.1f;

    private Animator animator;


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
        Caminar();
        Correr();
    }

    public void Correr()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-velocidadPlayer, 0, 0);
            animator.SetBool("correrIzquierda", true);
            animator.SetBool("caminarIzquierda", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("correrIzquierda", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(+velocidadPlayer, 0, 0);
            animator.SetBool("correrDerecha", true);
            animator.SetBool("caminarDerecha", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("correrDerecha", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, +velocidadPlayer, 0);
            animator.SetBool("correrArriba", true);
            animator.SetBool("caminarArriba", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("correrArriba", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, -velocidadPlayer, 0);
            animator.SetBool("correrAbajo", true);
            animator.SetBool("caminarAbajo", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("correrAbajo", false);
        }
    }

    public void Caminar()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-velocidadPlayer, 0, 0);
            animator.SetBool("caminarIzquierda", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(+velocidadPlayer, 0, 0);
            animator.SetBool("caminarDerecha", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, +velocidadPlayer, 0);
            animator.SetBool("caminarArriba", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -velocidadPlayer, 0);
            animator.SetBool("caminarAbajo", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("caminarArriba", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("caminarAbajo", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("caminarIzquierda", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("caminarDerecha", false);
        }
    }
}
