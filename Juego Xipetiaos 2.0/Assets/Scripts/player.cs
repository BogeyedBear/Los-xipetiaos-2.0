using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D playerRigidbody2D;
    Vector2 move;
    public float speed = 150;
    private float multiplier = 1;
    public int maxHealth = 100;
    public int currentHealth;
    //public QuitaVida movimientoNull;
    public PauseMenu menuNull;

    public CajaFuerte movimientoNull;

    public HealthBar healthBar;

    public GameObject sonidoPasos;

    public List<RuntimeAnimatorController> animators;

    public FOV fov;

    void Awake()
    {
        animator = GetComponent<Animator>();
        this.animator.runtimeAnimatorController = animators[PlayerPrefs.GetInt("Skin", 0)];
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = move * speed * multiplier * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asesino"))
        {
            TakeDamage(25);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (menuNull.animacionNull)
        {
            Walk();
        }


        fov.SetOrigin(transform.position);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Run()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Correr", true);
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
            multiplier = 1.5f;
        }
        else
        {
            animator.SetBool("Correr", false);
            multiplier = 1f;
        }
    }

    public void Walk()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        if((Input.GetAxisRaw("Horizontal") != 0f) || (Input.GetAxisRaw("Vertical") != 0f))
        {
            sonidoPasos.gameObject.SetActive(true);
            Run();
        }
        else
        {
            sonidoPasos.gameObject.SetActive(false);
            animator.SetBool("Correr", false);
            multiplier = 1f;
        }
    }

    /**public void Run()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 1.5f;
            animator.SetBool("correrIzquierda", true);
            animator.SetBool("caminarIzquierda", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 1.5f;
            animator.SetBool("correrDerecha", true);
            animator.SetBool("caminarDerecha", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 1.5f;
            animator.SetBool("correrArriba", true);
            animator.SetBool("caminarArriba", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 1.5f;
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
            multiplier = 1;
        }
    }**/

    /**public void WalkAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("caminarIzquierda", true);
            sonidoPasos.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("caminarDerecha", true);
            sonidoPasos.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("caminarArriba", true);
            sonidoPasos.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("caminarAbajo", true);
            sonidoPasos.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("caminarArriba", false);
            sonidoPasos.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("caminarAbajo", false);
            sonidoPasos.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("caminarIzquierda", false);
            sonidoPasos.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("caminarDerecha", false);
            sonidoPasos.gameObject.SetActive(false);
        }
    }**/
}
