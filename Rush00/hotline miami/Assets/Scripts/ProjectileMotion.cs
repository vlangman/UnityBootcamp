using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour {

	public Quaternion direction;
	public float mSpeed;

	// Use this for initialization
	void Start () {
		transform.rotation = direction;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		transform.Translate( transform.forward * mSpeed * Time.deltaTime , Space.World);
	}
}
