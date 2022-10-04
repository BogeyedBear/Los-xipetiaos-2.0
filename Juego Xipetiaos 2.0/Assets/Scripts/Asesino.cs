using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asesino : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("¡¡¡YOU DIED!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
