using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Asesino : MonoBehaviour
{

    public AIPath aiPath;
    private Animator animator;
    public GameObject died;
    public GameObject player;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            died.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            Debug.Log("���YOU DIED!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", false);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", true);

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("arribaE", false);
            animator.SetBool("izquierdaE", true);
            animator.SetBool("abajoE", false);
            animator.SetBool("derechaE", false);
        }
        else if (aiPath.desiredVelocity.y >= 0.01f)
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
