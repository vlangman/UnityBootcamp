
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
		if (GunOwner.layer == 15){
			GameObject Player = GameObject.FindGameObjectWithTag("Player");
			worldMousePos = Player.transform.position;
		}
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
		//layers for walls and doors respectively
	
		if (collider.gameObject.layer == 10 || collider.gameObject.layer == 11){
			Destroy(gameObject);
		}
		//player layer

			Debug.Log("OwnerLayer : " +  GunOwner.gameObject.layer);
			Debug.Log("Victim Layer : " + collider.gameObject.layer);

		//enemy shoots player
		if (collider.gameObject.layer == 8 && GunOwner.gameObject.layer == 15){
			Destroy(collider.gameObject);
		}
		//if player shoots enemy
		if (collider.gameObject.layer == 15 && GunOwner.gameObject.layer == 8){
			Destroy(collider.gameObject);
		}

	}

}
