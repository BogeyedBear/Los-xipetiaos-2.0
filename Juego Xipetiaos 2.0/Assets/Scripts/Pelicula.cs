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
    public bool activar = false;

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
        }
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
                this.panel.SetActive(true);
                activar = true;
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }
}
