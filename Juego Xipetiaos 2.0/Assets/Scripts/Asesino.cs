using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Asesino : MonoBehaviour
{

    public AIPath aiPath;

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
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
