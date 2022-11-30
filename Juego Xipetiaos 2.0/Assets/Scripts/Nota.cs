using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform nota;
    public GameObject panel;
    public GameObject mainPanel;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        Cerca();
    }

    private void Cerca()
    {
        float restaX = Mathf.Abs(nota.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(nota.position.y - player.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
            if (Input.GetKey(KeyCode.E))
            {
                this.panel.SetActive(true);
                this.mainPanel.SetActive(true);
            }
            else
            {
                this.panel.SetActive(false);
                this.mainPanel.SetActive(false);
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }
}
