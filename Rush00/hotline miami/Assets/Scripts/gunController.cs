using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public float projectileSpeed;
	public float rateOfFire;
	public Sprite playerGunSprite;
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
		if (Input.GetMouseButton(0)){
			fire = true;
		}else{
			fire = false;
		}
		
	}

	void FixedUpdate(){
		Timer+=Time.deltaTime;
		if (fire == true && Timer >= (1.0f/rateOfFire) && AmmoCount != 0){
			AmmoCount--;
			Vector3 offset = transform.position;
			Debug.Log("SpawnPos: " + offset);
			offset += Vector3.forward * 2.5f;
			Debug.Log("offset: " + offset);

			GameObject bullet = Instantiate(defaultProjectile, offset, transform.rotation);
			//assign its direction immediately after create
			bullet.GetComponent<ProjectileMotion>().mSpeed = projectileSpeed;
			bullet.GetComponent<ProjectileMotion>().gunTransform = transform.position;
			bullet.GetComponent<ProjectileMotion>().gunRotation = transform.rotation;
			bullet.GetComponent<ProjectileMotion>().GunOwner = mOwner;
			bullet.GetComponent<ProjectileMotion>().DeathTime = projectileLife;


			Timer = 0.0f;
		}
	}

	private void setGunStats(){
		if (gameObject.tag == "Revolver"){
			projectileSpeed = 10f;
			rateOfFire = 3f;
			AmmoCount = 10;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("RevolverProjectile");
		}
		if (gameObject.tag == "Uzi"){
			projectileSpeed = 10f;
			rateOfFire = 8f;
			AmmoCount = 25;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("UziProjectile");
		}
		if (gameObject.tag == "Katana"){
			projectileSpeed = 0f;
			rateOfFire = 2.5f;
			AmmoCount = 9999999;
			projectileLife = 0.3f;

			defaultProjectile = (GameObject)Resources.Load("KatanaProjectile");
		}
		if (gameObject.tag == "Raygun"){
			projectileSpeed = 15f;
			rateOfFire = 10f;
			AmmoCount = 9999999;
			projectileLife = 8f;
			defaultProjectile = (GameObject)Resources.Load("RaygunProjectile");
		}
	}

	public void Fire(){

	}
}
