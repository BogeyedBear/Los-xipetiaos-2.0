using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFuerte : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform cajaFuerte;
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
    }

    private void Cerca()
    {
        float restaX = Mathf.Abs(cajaFuerte.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(cajaFuerte.position.y - player.transform.position.y);
        float min = Mathf.Min(restaX, restaY);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
        }
        else
        {
            animator.SetBool("cerca", false);
        }
    }
}
