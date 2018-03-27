using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{

    public float attackRange = 7;
    float moveDirX;
	float moveDirZ;


	private Vector3 karate;
    public GameObject Player;


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


        if (Vector3.Distance(transform.position, Player.transform.position) < 7)
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
        
		moveDirX = transform.position.x +Random.Range(-1,1) ;
        moveDirZ = transform.position.z + Random.Range(-1,1) ;
		karate = new Vector3(moveDirX, 0.5f, moveDirZ);
        transform.position = Vector3.Slerp(transform.position, karate, 0.05f);
		if (playerIsNear)
		{

			brain = new FSM(Chase);
		}
		//throw new System.NotImplementedException();
	}

	private void Chase()
	{
        transform.position = Vector3.Lerp(transform.position, Player.transform.position - Vector3.one, 0.01f);


		if (!playerIsNear)
		{
            brain = new FSM(Patrol);
		}
		if (reachedPlayer)
		{

			Debug.Log("karate");
            brain = new FSM(Fight);
		}
		//throw new System.NotImplementedException();
	}

	private void Fight()
	{
		throw new System.NotImplementedException();
	}


}