using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D playerRigidbody2D;
    Vector2 move;
    public float speed = 150;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = move * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        CaminarAnimacion();
        Correr();
    }

    public void Correr()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 300;
            animator.SetBool("correrIzquierda", true);
            animator.SetBool("caminarIzquierda", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 300;
            animator.SetBool("correrDerecha", true);
            animator.SetBool("caminarDerecha", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 300;
            animator.SetBool("correrArriba", true);
            animator.SetBool("caminarArriba", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 300;
            animator.SetBool("correrAbajo", true);
            animator.SetBool("caminarAbajo", false);
        }
        if (Input.GetKeyUp(KeyCode.A)) 
        {
            animator.SetBool("correrIzquierda", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("correrDerecha", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("correrArriba", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("correrAbajo", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("correrAbajo", false);
            animator.SetBool("correrArriba", false);
            animator.SetBool("correrIzquierda", false);
            animator.SetBool("correrDerecha", false);
            speed = 150;
        }
    }

    public void CaminarAnimacion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("caminarIzquierda", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("caminarDerecha", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("caminarArriba", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
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
