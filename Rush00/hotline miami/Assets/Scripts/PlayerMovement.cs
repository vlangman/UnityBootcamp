using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public 	Animator animator;
	public float moveSpeed;
	public bool isMoving;
	[HideInInspector]
	public GameObject legs;

	public GameObject playerGun;
	public GameObject currentWeapon;
	public Vector2 offset;
	// Use this for initialization
	void Start () {
		moveSpeed = 5.5f;
		animator = GetComponentInChildren<Animator>();
		currentWeapon = null;
		offset =  new Vector2(0.022f,-0.254f);
	}
	
	// Update is called once per frame
	void Update () {
		//rotate player to face mouse cursor
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(transform.position, mouseOnScreen) - 90f;
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
		Debug.DrawLine(transform.position, mouseOnScreen);
		//set player moving
		if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d")){
			isMoving = false;
		}else{
			isMoving = true;
		}
		animator.SetBool("isMoving", isMoving);
	}


	void FixedUpdate(){
		if (isMoving){
			if (Input.GetKey("a")){
				transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			}
			if (Input.GetKey("d")){
				transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			}
			if (Input.GetKey("s")){
				transform.position = new Vector3(transform.position.x , transform.position.y - moveSpeed * Time.deltaTime, transform.position.z );
			}
			if (Input.GetKey("w")){
				transform.position = new Vector3(transform.position.x , transform.position.y + moveSpeed * Time.deltaTime, transform.position.z );
			}
		}

	}

	//utility
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		//get gradient in degrees
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	private void OnTriggerStay2D(Collider2D victim)
	{

		if (victim.gameObject.layer == 9){
			if (Input.GetKeyDown("e")){
				//get the weapon bru
				Debug.Log("Equiping weapon: " + victim.gameObject.name );
				//pass the prefab not the weapn //instance it firsdt!!!!
				GameObject newWeapon = victim.gameObject.GetComponent<WeaponPickup>().playersGunPrefab;
				EquipWeapon(newWeapon);
				Destroy(victim.gameObject);
			}
		}
	}

	private void EquipWeapon(GameObject newWeapon){
		//use this to throw guns when equip
		if (currentWeapon != null)
		{
			Destroy(currentWeapon.gameObject);
		}

	//instantiate the weapon
		currentWeapon = Instantiate(newWeapon, playerGun.gameObject.transform.position, playerGun.gameObject.transform.rotation,  gameObject.transform);
		currentWeapon.GetComponent<gunController>().mOwner = gameObject;
	//apply gun specifications


	}
}
