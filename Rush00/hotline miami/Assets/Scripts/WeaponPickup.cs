using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	public bool isThrown;
	public Vector3 target;
	public GameObject playersGunPrefab;
	public bool isSpinning;
	float timer;
	float SpinTime = 5f;
	float speed = 100;

	void Start(){
		isThrown = false;
	}

	public void ThrowWeapon(Vector3 location){
		isThrown = true;
		target = location;
	}

	void FixedUpdate(){
		if (isThrown){
			transform.position = Vector3.MoveTowards(transform.position, target, 2.0f * Time.deltaTime);
			if ( transform.position == target){
				isThrown = false;
			}
		}
		if (isSpinning){
			spinGun();
		}
	}

	void spinGun(){
		
		float speed = 1f;
		if(timer <= SpinTime )
		{
			Quaternion rot = transform.rotation;
			rot.z +=  speed;
			transform.rotation = rot;
			timer += Time.deltaTime;
		}else{
			isSpinning = false;
		}
	}
}