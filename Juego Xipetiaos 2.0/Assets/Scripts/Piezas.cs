using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas : MonoBehaviour
{

    public float parts = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pieza"))
        {
            Destroy(collision.gameObject);
            parts = parts + 1f;
            Debug.Log("!!!Has encontrado una pieza???(" + parts + "/6)");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
