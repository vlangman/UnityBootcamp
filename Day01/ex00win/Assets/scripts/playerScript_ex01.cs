using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour {



	public Rigidbody2D rigidBody;
	public Transform groundCheck;
	public bool grounded;
	public float moveForce = 1000.0f;
	public float jumpForce = 3000f;
	public float maxSpeed = 5f;

	private	GameObject redEndGate;
	private	GameObject yellowEndGate;
	private	GameObject blueEndGate;
	private bool jump;
	private BoxCollider2D m_Collider;
	static GameObject currentObject;


	// Use this for initialization
	void Awake () {
		redEndGate = GameObject.FindWithTag("redEndGate");
		blueEndGate = GameObject.FindWithTag("blueEndGate");
		yellowEndGate = GameObject.FindWithTag("yellowEndGate");
		grounded = false;
		currentObject = GameObject.FindWithTag("blue");
		jumpForce = 10000.0f; 
		moveForce = 500f;
		maxSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("1")){
			currentObject = GameObject.FindWithTag("red");
			jumpForce = 15000.0f;
			moveForce = 1000f;
			maxSpeed = 5f;

		} else if (Input.GetKeyDown("2")){
			currentObject = GameObject.FindWithTag("blue");
			jumpForce = 10000.0f;
			moveForce = 500f;
			maxSpeed = 3f;
		} else if (Input.GetKeyDown("3")){
			currentObject = GameObject.FindWithTag("yellow");
			jumpForce = 20000.0f;
			moveForce = 1500f;
			maxSpeed = 7f;
		}
		else if (Input.GetKeyDown("r")){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if (Input.GetKeyDown("space") && grounded){
			jump = true;
			grounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
    	Debug.Log("collision");
         foreach (ContactPoint2D contact in collision.contacts) {
            // print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.red, 0.5f);
            Debug.Log(contact.normal);
            //if normal for contact point -1 ((-90))
            if (contact.normal.x == 0.0f && contact.normal.y == 1.0f){
            	grounded = true;
            }
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
