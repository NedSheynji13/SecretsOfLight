using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour {

	public Animator anim;
	public float speed;
	public float maxSpeed;
	public float walkSpeedMultiplyer;
	public bool isJumping;
	public float playRandom1;
	public float playRandom2;
	public bool random1IsPlaying;
	public bool random2IsPlaying;

	void Update(){
		if (Input.GetKey (KeyCode.D)) {

			transform.eulerAngles = new Vector3 (0, 90, 0);
			
			if (speed <= maxSpeed) {
				speed += Time.deltaTime;
			}

			if (!isJumping && Input.GetKeyDown(KeyCode.Space)) {
				anim.SetBool ("Jump", true);
				Invoke ("ResetJump", 1.5f);
			}
		}

		if (Input.GetKey(KeyCode.A)) {

			transform.eulerAngles = new Vector3 (0, -90, 0);

			if (speed <= maxSpeed) {
				speed += Time.deltaTime;
			}

			if (!isJumping && Input.GetKeyDown(KeyCode.Space)) {
				anim.SetBool ("Jump", true);
				Invoke ("ResetJump", 1.5f);
			}
		}

		if (speed < 0) {
			speed -= Time.deltaTime * 0.4f;
		} else if (speed > 0) {
			speed -= Time.deltaTime * 0.4f;
		}

		if (!random1IsPlaying) {
			random1IsPlaying = true;
			Invoke ("PlayRandom1", playRandom1);
		}

		if (!random2IsPlaying) {
			random2IsPlaying = true;
			Invoke ("PlayRandom2", playRandom2);
		}

		anim.SetFloat ("WalkSpeed", speed);

	}

	void FixedUpdate(){
		if (Mathf.Abs (speed) > 0.05f) {
			transform.Translate (new Vector3 (0, 0, speed) * walkSpeedMultiplyer);
		}
	}

	void ResetJump(){
		anim.SetBool ("Jump", false);
		isJumping = false;
	}

	void PlayRandom1(){
		anim.SetBool ("Random1", true);
		Invoke ("ResetRandom1", 3.3f);
	}

	void PlayRandom2(){
		anim.SetBool ("Random2", true);
		Invoke ("ResetRandom2", 4.3f);
	}

	void ResetRandom1(){
		anim.SetBool ("Random1", false);
		random1IsPlaying = false;
	}

	void ResetRandom2(){
		anim.SetBool ("Random2", false);
		random2IsPlaying = false;
	}
}
