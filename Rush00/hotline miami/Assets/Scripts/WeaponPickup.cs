using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

	public bool isThrown;
	public Vector3 target;
	public GameObject playersGunPrefab;


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
	}
}
