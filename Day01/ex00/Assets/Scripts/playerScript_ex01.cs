using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour {

	public Rigidbody2D rigidBody;

	public Transform groundCheck;
	public bool grounded;
	private bool jump;
	private float moveForce = 1000.0f;
	private float jumpForce = 3000f;
	private float maxSpeed = 5f;
	private BoxCollider2D m_Collider;
	static GameObject currentObject;

	// Use this for initialization
	void Awake () {
		jump = false;
		currentObject = GameObject.FindWithTag("blue");
		jumpForce = 2000.0f;
		moveForce = 500f;
		maxSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("1")){
			currentObject = GameObject.FindWithTag("red");
			jumpForce = 3500.0f;
			moveForce = 1000f;
			maxSpeed = 5f;

		} else if (Input.GetKeyDown("2")){
			currentObject = GameObject.FindWithTag("blue");
			jumpForce = 2500.0f;
			moveForce = 500f;
			maxSpeed = 5f;
		} else if (Input.GetKeyDown("3")){
			currentObject = GameObject.FindWithTag("yellow");
			jumpForce = 5000.0f;
			moveForce = 1500f;
			maxSpeed = 7f;
		}
		else if (Input.GetKeyDown("r")){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		// grounded = Physics2D.Linecast(currentObject.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		// Debug.DrawLine(currentObject.transform.position, groundCheck.position, Color.green, 2.5f);

		m_Collider = GetComponent<BoxCollider2D>();

	// Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
		grounded = Physics2D.Raycast(transform.position, Vector3.down, m_Collider.size.y/2.0f + 0.1f, LayerMask.NameToLayer("Ground"));
		Debug.DrawRay(transform.position, Vector3.down, Color.green);
		Debug.Log("Grounded : " + grounded);
		// Debug.DrawRay(currentObject.transform.position, groundCheck.position, Color.green, 0.5f, false);
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
