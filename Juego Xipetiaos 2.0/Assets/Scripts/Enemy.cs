using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variable to reference the state Machine
    //[SerializeField] private StateMachine currentStateEnemy;

    // Variable to reference the player
    private Player player;

    // making a vision rate
    [SerializeField] private float _visionRate;

    // Creting a Vector to have the initial position of the enemy
    [SerializeField] private Vector3 initialPos;

    // Enemy Velocity
    [SerializeField] private float enemySpeed;

    // reference points list
    [SerializeField] private List<Transform> listPositionsToMove;

    //private bool isMoving = false;

    [SerializeField] private int randomNumber;

    [SerializeField] private float timer = 5f;

    private void Awake()
    {
        // Searching in the hierarchy if exist a gameobject with the script Player
        player = FindObjectOfType<Player>();

        // Changing the state of the StateMachine
        //currentStateEnemy = StateMachine.idle;
    }

    private void Update()
    {
        // Call the method PlayerFollow
        // PlayerFollow();

        MoveToReferencesPoints();

        timer -= Time.deltaTime;
        if (timer < 0) 
        {
            RandomNumber();
            timer = 3;
        }
        

    }

    /// <summary>
    /// This Method follow the player when this stay in the rate vision
    /// </summary>
    public void PlayerFollow()
    {
        Vector3 target = initialPos;

        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance < _visionRate)
        {
            target = player.transform.position;
            //currentStateEnemy = StateMachine.follow;
        }
        else
        {
            //currentStateEnemy = StateMachine.patrol;
        }

        float fixedSpeed = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // Draw the movement of the ghos BOO
        Debug.DrawLine(transform.position, target, Color.blue);
    }

    public int RandomNumber() 
    {
        randomNumber++;
        if (randomNumber == listPositionsToMove.Count) 
        {
            randomNumber = 0; 
        }
        return randomNumber;
    }
    public void MoveToReferencesPoints() 
    {
        Vector3 target = initialPos;
        
        float fixedSpeed = enemySpeed * Time.deltaTime;
        target = listPositionsToMove[randomNumber].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, listPositionsToMove[randomNumber].transform.position, Color.blue);
           
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _visionRate);
    }

}


// Creating a stateMachine with enums
public enum StateMachine { None, patrol, follow, idle }
