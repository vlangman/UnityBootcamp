using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Playerpos;
	public float mSpeed;
	public float detectionDistance;

	// Use this for initialization
	void Start () {
		Playerpos = GameObject.FindGameObjectWithTag("Player").transform;
		mSpeed = 3.5f;
		detectionDistance = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		// if (Vector2.Distance(transform.position, Playerpos.position) < detectionDistance){
			transform.position = Vector2.MoveTowards(transform.position, Playerpos.position, mSpeed*Time.deltaTime);
		// }
	}
}
