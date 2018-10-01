using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public int pipeCount =1;
	public float speed = 2.5f;
	bool startMove = false;
	float Timer = 0.0f;
	float startTime = 0.0f;
	float waitTime;
	int Score;
	bool incScore = true;
	Vector3 originalPos;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		originalPos = transform.position;
		waitTime = 3.0f * pipeCount;
		Score = 0;
	}
	
	void FixedUpdate () {
		Timer = Time.time;
		if (Timer - startTime >= waitTime){
			startMove = true;
		}

		if (startMove){
			Move();
		}else{
			
		}

	}

	void Move(){
		transform.Translate(Vector3.left* speed * Time.deltaTime, Space.World);
		
		if (transform.position.x < 0.90 && incScore){
			Score+=5;
			Debug.Log("Score: " + Score);
			Debug.Log("Time: " +  Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
			incScore = false;
			speed += 0.2f;
		}


		if (transform.position.x <= -3.44f){
			waitTime = 5.0f;
			startTime = Time.time;
			startMove = false;
			transform.position = originalPos;
			incScore = true;
		}
	}

	public void setCount(int count){
		pipeCount = count;
	}

}
