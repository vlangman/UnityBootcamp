using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex00 : MonoBehaviour {

	public Rigidbody2D rigidBody;

	public Transform groundCheck;
	private bool grounded = false;
	private bool jump;
	private float moveForce = 1000.0f;
	float jumpForce = 3000f;
	private float maxSpeed = 5f;

	static GameObject currentObject;

	// Use this for initialization
	void Awake () {
		jump = false;
		currentObject = GameObject.FindWithTag("blue");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("1")){
			currentObject = GameObject.FindWithTag("red");;
		} else if (Input.GetKeyDown("2")){
			currentObject = GameObject.FindWithTag("blue");;
		} else if (Input.GetKeyDown("3")){
			currentObject = GameObject.FindWithTag("yellow");;
		}
		else if (Input.GetKeyDown("r")){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		grounded = Physics2D.Linecast(currentObject.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetKeyDown("space") && grounded){
			jump = true;
		}
	}

	void FixedUpdate(){
		rigidBody = currentObject.GetComponent<Rigidbody2D>();
		float hSpeed = Input.GetAxis("Horizontal");

		//set the velocity if not over max
		if (hSpeed * rigidBody.velocity.x < maxSpeed)
            rigidBody.AddForce(Vector2.right * hSpeed * moveForce * Time.deltaTime);

    	//clamp the velocity
        // check direction and set max speed to that dir
        if (Mathf.Abs (rigidBody.velocity.x) > maxSpeed)
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);


        if (jump)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce) * Time.deltaTime);
            jump = false;
        }
	}
}
