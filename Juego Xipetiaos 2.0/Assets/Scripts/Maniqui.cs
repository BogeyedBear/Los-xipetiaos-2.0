using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Maniqui : MonoBehaviour
{
    [SerializeField] private Vector3 direction = new Vector3(0,1f,0);
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D maniquiRigidBody;

    private void Update()
    {
        maniquiRigidBody.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("maniqui"))
        {
            this.direction *= -1f;
        }
    }
}
