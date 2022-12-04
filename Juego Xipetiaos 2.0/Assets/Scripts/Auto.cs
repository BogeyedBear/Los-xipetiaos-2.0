using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform auto;
    public AudioSource fuente;
    public AudioClip clip;
    public Piezas partes;
    private bool sonido = true;
    public GameObject win;

    void Awake()
    {
        animator = GetComponent<Animator>();
        fuente.clip = clip;
    }
    // Start is called before the first frame update
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

        float restaX = Mathf.Abs(auto.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(auto.position.y - player.transform.position.y);
        if (restaX < 2f && restaY < 3f)
        {
            if(partes.parts == 6f)
            {
                animator.SetBool("cerca", true);
                if (Input.GetKey(KeyCode.E))
                {
                    StartCoroutine(Arreglar());
                    animator.SetBool("fin", true);

                    if (sonido == true)
                    {
                        fuente.Play();
                        sonido = false;
                    }
                }
            }
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }

    IEnumerator Arreglar()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(15f);
        fuente.Stop();
        this.win.SetActive(true);

    }
}
