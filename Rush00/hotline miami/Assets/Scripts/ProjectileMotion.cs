
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour {

	//speed set from outside
	public float mSpeed;
	public Vector2 direction;
	public Vector3 gunTransform;
	public Quaternion gunRotation;
	public GameObject GunOwner;
	public float DeathTime;

	private float timer;


	// Use this for initialization
	void Start () {
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = (Vector2)((worldMousePos - gunTransform));
 		direction.Normalize();
 		transform.rotation = gunRotation;
 		Vector3 faceForward = transform.eulerAngles;
 		faceForward.z -=90f;
 		transform.eulerAngles = faceForward;
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void FixedUpdate(){
		transform.Translate(direction * mSpeed * Time.deltaTime, Space.World);
		timer+=Time.deltaTime;
		if (timer >= DeathTime){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collider){

		Debug.Log(collider.gameObject.layer);
		//layers for walls and doors respectively
		Debug.Log(collider.gameObject.tag);
		if (collider.gameObject.layer == 10 || collider.gameObject.layer == 11){
			Destroy(gameObject);
		}
		//player layer
		if (collider.gameObject.layer == 8 && GunOwner.gameObject.layer != 8){
			Destroy(collider.gameObject);
		}

	}

}
