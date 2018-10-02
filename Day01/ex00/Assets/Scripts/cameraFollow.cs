using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject blue;
	public GameObject red;
	public GameObject yellow;

	public GameObject currentObjectToFollow;

	// Use this for initialization
	void Start () {
		blue = GameObject.FindWithTag("blue");
		red = GameObject.FindWithTag("red");
		yellow = GameObject.FindWithTag("yellow");

		currentObjectToFollow = blue;
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyDown("1")){
			currentObjectToFollow = red;
		} else if (Input.GetKeyDown("2")){
			currentObjectToFollow = blue;
		} else if (Input.GetKeyDown("3")){
			currentObjectToFollow = yellow;
		}

		transform.position = new Vector3(currentObjectToFollow.transform.position.x, currentObjectToFollow.transform.position.y, currentObjectToFollow.transform.position.z - 10f);
	}
}
