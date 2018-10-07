using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public float projectileSpeed;
	public float rateOfFire;
	public Sprite playerGunSprite;
	public GameObject throwGunObject;
	public GameObject defaultProjectile;
	public GameObject mOwner;
	public int AmmoCount;
	private float Timer;
	private bool fire;
	private float projectileLife;
	// Use this for initialization
	void Start () {
		setGunStats();
	}
	
	// Update is called once per frame
	void Update () {
		if (mOwner.gameObject.layer != 15){
			if (Input.GetMouseButton(0) && AmmoCount != 0){
				fire = true;
				if (mOwner.GetComponent<PlayerMovement>())
					mOwner.GetComponent<PlayerMovement>().isShooting = true;
			}else{
				fire = false;
				if (mOwner.GetComponent<PlayerMovement>())
					mOwner.GetComponent<PlayerMovement>().isShooting = false;
			}
			if (Input.GetMouseButton(1)){
				fire = false;
				ThrowGun();
			}
		}else{
			fire = false;
		}

	}

	void FixedUpdate(){
		Timer+=Time.deltaTime;
		if (fire == true && Timer >= (1.0f/rateOfFire) && AmmoCount != 0){
			AmmoCount--;
			Vector3 offset = transform.position;
			offset += Vector3.forward * 2.5f;
			GameObject bullet = Instantiate(defaultProjectile, offset, mOwner.gameObject.transform.rotation);
			//assign its direction immediately after create
			bullet.GetComponent<ProjectileMotion>().mSpeed = projectileSpeed;
			bullet.GetComponent<ProjectileMotion>().gunTransform = transform.position;
			bullet.GetComponent<ProjectileMotion>().gunRotation = transform.rotation;
			bullet.GetComponent<ProjectileMotion>().GunOwner = mOwner;
			bullet.GetComponent<ProjectileMotion>().DeathTime = projectileLife;


			Timer = 0.0f;
		}
	}

	private void ThrowGun(){
		mOwner.GetComponent<PlayerMovement>().ThrowGun(throwGunObject);
	}

	private void setGunStats(){
		if (gameObject.tag == "Revolver"){
			projectileSpeed = 10f;
			rateOfFire = 3f;
			AmmoCount = 10;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("RevolverProjectile");
			 throwGunObject = (GameObject)Resources.Load("Revolver");

		}
		if (gameObject.tag == "Uzi"){
			projectileSpeed = 10f;
			rateOfFire = 8f;
			AmmoCount = 25;
			projectileLife = 8f;

			defaultProjectile = (GameObject)Resources.Load("UziProjectile");
			 throwGunObject = (GameObject)Resources.Load("Uzi");
		}
		if (gameObject.tag == "Katana"){
			projectileSpeed = 0f;
			rateOfFire = 2.5f;
			AmmoCount = 9999999;
			projectileLife = 0.3f;

			defaultProjectile = (GameObject)Resources.Load("KatanaProjectile");
			 throwGunObject = (GameObject)Resources.Load("Katana");



		}
		if (gameObject.tag == "Raygun"){
			projectileSpeed = 15f;
			rateOfFire = 10f;
			AmmoCount = 25;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("RaygunProjectile");
			 throwGunObject = (GameObject)Resources.Load("Raygun");

		}
		if (gameObject.tag == "EnemyGun"){
			projectileSpeed = 15f;
			rateOfFire = 10f;
			AmmoCount = 99999999;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("enemyProjectile");
			throwGunObject = (GameObject)Resources.Load("Uzi");
		}
	}

	public void setFire(bool fireMode){
		fire = fireMode;
	}

}
