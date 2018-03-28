using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{

    public float attackRange = 7;
    float moveDirX;
	float moveDirY;


	private Vector3 karate;
    private Vector3 abstand;

    public GameObject Player;
    public GameObject Deer;



    public bool playerIsSafe = false;

	public bool playerIsNear = false;
	public bool reachedPlayer = false;
	private FSM brain;



	private void Awake()
	{
		brain = new FSM(Patrol);


	}

	private void Update()
	{
		brain.Update();


        if (Vector3.Distance(transform.position, Player.transform.position) < 6)
        {
            playerIsNear = true;
        }
            else
            {
                playerIsNear = false;
            }

            if (Vector3.Distance(transform.position, Player.transform.position) < 1)
            {
                reachedPlayer = true;
            }

        else
        {
            reachedPlayer = false;

		}
  	}

	

    private void Patrol()
	{
        
		moveDirX = transform.position.x +Random.Range(-0.1f,0.1f) ;
        moveDirY = transform.position.y + Random.Range(-0.1f, 0.1f);
		karate = new Vector3(moveDirX, moveDirY, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, karate, 0.05f);
		if (playerIsNear)
		{

			brain = new FSM(Chase);
		}
		//throw new System.NotImplementedException();
	}

	private void Chase()
	{
        transform.rotation = Deer.transform.rotation;
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.01f);
    

		if (!playerIsNear)
		{
            brain = new FSM(Patrol);
		}
		if (reachedPlayer)
		{

			Debug.Log("karate");
            brain = new FSM(Patrol);
        }
        //throw new System.NotImplementedException();
    }

	private void Fight()
	{
		throw new System.NotImplementedException();
	}


}