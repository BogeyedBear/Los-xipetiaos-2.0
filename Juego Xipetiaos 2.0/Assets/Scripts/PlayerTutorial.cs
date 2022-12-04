using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D playerRigidbody2D;
    public PauseMenu menuNull;
    Vector2 move;
    public List<RuntimeAnimatorController> animators;
    public float speed = 150;
    public GameObject sonidoPasos;
    private float multiplier = 1;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        this.animator.runtimeAnimatorController = animators[PlayerPrefs.GetInt("Skin", 0)];
    }

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (menuNull.animacionNull)
        {
            Walk();
        }
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = move * speed * multiplier * Time.deltaTime;
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
        if ((Input.GetAxisRaw("Horizontal") != 0f) || (Input.GetAxisRaw("Vertical") != 0f))
        {
            sonidoPasos.gameObject.SetActive(true);
            Run();
        }
        else
        {
            sonidoPasos.gameObject.SetActive(false);
            animator.SetBool("Correr", false);
        }
    }
}
