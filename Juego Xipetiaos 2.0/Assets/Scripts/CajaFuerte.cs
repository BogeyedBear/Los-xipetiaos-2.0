using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CajaFuerte : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform cajaFuerte;
    public GameObject task;
    public GameObject mainPanel;
    public PanelTask completao;
    public bool movimiento = true;
    public GameObject minijuego;
    public GameObject minijuegowin;
    //bool playerClose;
    // Start is called before the first frame update

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cerca();
        if (completao.abierto)
        {
            animator.SetBool("completao", completao.abierto);
        }
        /**if (IsTaskActive() && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(task);
        }**/
    }

    /**private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = true;
        }
    }**/

    /**private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
        }
    }**/

    private void Cerca()
    {
        float restaX = Mathf.Abs(cajaFuerte.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(cajaFuerte.position.y - player.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.task.SetActive(true);
                this.mainPanel.SetActive(true);
                this.minijuego.SetActive(false);
                this.minijuegowin.SetActive(true);
                Time.timeScale = 0f;
                movimiento = false;
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }

    /**private bool IsTaskActive()
    {
        return playerClose && !GameObject.FindWithTag("Task");
    }**/
}
