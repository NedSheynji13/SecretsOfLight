using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_mov_Vec : MonoBehaviour {

    public float speed = 5;

    private Vector3 inputDirection;
	void Start () {
		
	}
	
	void Update ()
    {
        inputDirection.x = Input.GetAxis("Horizontal");

        if (inputDirection.magnitude < 0.19f)
        {

            inputDirection = Vector3.zero;
        }

        inputDirection = Vector3.ClampMagnitude(new Vector3(inputDirection.x, 0, 0), 1);
        inputDirection *= new Vector3(inputDirection.x, 0, 0).magnitude * speed;
    }
}
