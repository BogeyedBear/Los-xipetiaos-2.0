using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using System;

public class Asesino : MonoBehaviour
{

    public AIPath aiPath;
    private Animator animator;
    public Transform playerTransform;
    public Transform holder;
    public AIDestinationSetter ai;
    [SerializeField] private List<Transform> listPositionsToMove;
    private System.Random creadorNumeros = new System.Random();
    [SerializeField] private int posicion;
    public int rangoDeVision;
    private float horizontal;
    private float vertical;
    public AudioSource fuente;
    public AudioClip clip;
    //public GameObject died;
    //public GameObject player;
    //public GameObject Reset;
    //public GameObject Negro;
    //private float hits = 0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Patrullar()
    {
        if(Mathf.Abs(Vector2.Distance(playerTransform.position, holder.position))>rangoDeVision)
        {
            ai.target = listPositionsToMove[posicion];
        }
        else
        {
            ai.target = playerTransform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            int aux = this.creadorNumeros.Next(0, listPositionsToMove.Count);
            while(aux == this.posicion)
            {
                aux = this.creadorNumeros.Next(0, listPositionsToMove.Count);
            }
            posicion = aux;
        }
    }

    private void AttackDown()
    {
        float restaX = Mathf.Abs(playerTransform.position.x - holder.transform.position.x);
        float restaY = Mathf.Abs(playerTransform.position.y - holder.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("AtaqueAbajo", true);
        }
        else
        {
            animator.SetBool("AtaqueAbajo", false);
        }
    }
    
    /**private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Debug.Log("¡¡¡YOU DIED!!!");
            hits = +1f;
        }
        if (hits == 4f)
        {
            //Destroy(collision.gameObject);
            Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Debug.Log("¡¡¡YOU DIED!!!");
        }
    }**/

    // Update is called once per frame
    void Update()
    {
        Patrullar();

        /**if (hits == 4f)
        {
            //Destroy(collision.gameObject);
            Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Debug.Log("¡¡¡YOU DIED!!!");
        }**/
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            horizontal = 1f;
            vertical = 0f;
            Animacion();
            float restaX = Mathf.Abs(playerTransform.position.x - holder.transform.position.x);
            float restaY = Mathf.Abs(playerTransform.position.y - holder.transform.position.y);
            float min = Mathf.Min(restaX, restaY);
            if (min < 0.3f)
            {
                animator.SetBool("Atacando", true);

            }
            if (min > 0.3f)
            {
                animator.SetBool("Atacando", false);
            }
            //transform.localScale = new Vector3(1f, 1f, 1f);
            /**animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", true);**/
            //Opcion de movimiento
            /**if (aiPath.desiredVelocity.y >= 0.01f)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("arribaE", true);
                animator.SetBool("izquierdaE", false);
                animator.SetBool("abajoE", false);
                animator.SetBool("derechaE", false);

            }
            else if (aiPath.desiredVelocity.y <= -0.01f)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("arribaE", false);
                animator.SetBool("izquierdaE", false);
                animator.SetBool("abajoE", true);
                animator.SetBool("derechaE", false);
            }**/
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            horizontal = -1f;
            vertical = 0f;
            Animacion();
            float restaX = Mathf.Abs(playerTransform.position.x - holder.transform.position.x);
            float restaY = Mathf.Abs(playerTransform.position.y - holder.transform.position.y);
            float min = Mathf.Min(restaX, restaY);
            if (min < 0.3f)
            {
                animator.SetBool("Atacando", true);

            }
            if (min > 0.3f)
            {
                animator.SetBool("Atacando", false);
            }
            //transform.localScale = new Vector3(1f, 1f, 1f);
            /**animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", true);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);**/
            //Opcion de movimieno
            /**if (aiPath.desiredVelocity.y >= 0.01f)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("arribaE", true);
                animator.SetBool("izquierdaE", false);
                animator.SetBool("abajoE", false);
                animator.SetBool("derechaE", false);
            }
            else if (aiPath.desiredVelocity.y <= -0.01f)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("arribaE", false);
                animator.SetBool("izquierdaE", false);
                animator.SetBool("abajoE", true);
                animator.SetBool("derechaE", false);
            }**/
        }
        else if (aiPath.desiredVelocity.y >= 0.01f)
        {
            horizontal = 0f;
            vertical = 1f;
            Animacion();
            float restaX = Mathf.Abs(playerTransform.position.x - holder.transform.position.x);
            float restaY = Mathf.Abs(playerTransform.position.y - holder.transform.position.y);
            float min = Mathf.Min(restaX, restaY);
            if (min < 0.3f)
            {
                animator.SetBool("Atacando", true);

            }
            if (min > 0.3f)
            {
                animator.SetBool("Atacando", false);
            }
            //transform.localScale = new Vector3(1f, 1f, 1f);
            /**animator.SetBool("arribaE", true);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);**/
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            horizontal = 0f;
            vertical = -1f;
            Animacion();
            float restaX = Mathf.Abs(playerTransform.position.x - holder.transform.position.x);
            float restaY = Mathf.Abs(playerTransform.position.y - holder.transform.position.y);
            float min = Mathf.Min(restaX, restaY);
            if (min < 0.3f)
            {
                animator.SetBool("Atacando", true);

            }
            if (min > 0.3f)
            {
                animator.SetBool("Atacando", false);
            }
            //transform.localScale = new Vector3(1f, 1f, 1f);
            /**animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", true);
            animator.SetBool("derechaE", false);**/
            //AttackDown();
        }
        //abajo();
        //arriba();
        //derecha();
        //izquierda();
        /**if (aiPath.desiredVelocity.y >= 0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", true);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);
        }
        if (aiPath.desiredVelocity.y <= -0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", true);
            animator.SetBool("derechaE", false);
        }**/
    }

    private void Animacion()
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

    private void abajo()
    {
        if (aiPath.desiredVelocity.y <= -0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", true);
            animator.SetBool("derechaE", false);
        }
    }
    private void arriba()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", true);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);
        }
    }
    private void derecha()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", true);
        }
    }
    private void izquierda()
    {
        if (aiPath.desiredVelocity.x <= -0.01f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", true);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);
        }
    }
}
