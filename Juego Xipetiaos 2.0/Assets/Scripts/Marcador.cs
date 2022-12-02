using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public Pelota puntos;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puntos.puntos == 1)
        {
            animator.SetBool("1", true);
        }
        if (puntos.puntos == 2)
        {
            animator.SetBool("2", true);
        }
        if (puntos.puntos == 3)
        {
            animator.SetBool("3", true);
        }
    }
}
