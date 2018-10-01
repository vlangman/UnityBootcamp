using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public Pipe pipe1;
	public Pipe pipe2;
	float gravity = 0.2f;
	float jumpPower = 6.5f;
	float velocity = 0.0f;

	// Use this for initialization
	void Start () {
		pipe1.setCount(1);
		pipe2.setCount(2);
	}
	
	void FixedUpdate () {
		transform.Translate(Vector3.down * Time.deltaTime * velocity);
		velocity += gravity;

		if (Input.GetKeyDown("up")){
			velocity = -jumpPower;
			Debug.Log("Space");
		}
	}


	bool checkCollision(){
		float birdScale = transform.localScale.x;
		float pipeScale = pipe1.transform.localScale.x;
		// if bird right side of bird (x + scale) bigger than left side wall( x - scale ) 
		if (transform.position.x + birdScale > pipe1.transform.position.x - pipeScale){
			//check top side and bot side collision
			if (transform.position.y )

		}
		return true;
	}
}
