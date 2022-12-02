using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Maniqui : MonoBehaviour
{
    [SerializeField] private List<Transform> PuntosManiqui;
    public AIDestinationSetter ai;
    [SerializeField] private int posicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ai.target = PuntosManiqui[posicion];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("maniqui"))
        {
            while (true)
            {
                if (posicion == 0)
                {
                    posicion = 1;
                }
                else if (posicion == 1)
                {
                    posicion = 0;
                }
            }
            /**while (posicion == 1)
            {
                posicion = 0;
            }**/
        }
    }
}
