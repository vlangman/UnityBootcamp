using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public float projectileSpeed;
	public float rateOfFire;
	public Sprite playerGunSprite;
	public GameObject defaultProjectile;

	private float Timer;
	private bool fire;
	// Use this for initialization
	void Start () {

		setGunStats();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			fire = true;
		}else{
			fire = false;
		}
		
	}

	void FixedUpdate(){
		Timer+=Time.deltaTime;
		if (fire == true && Timer >= (1.0f/rateOfFire)){
			Debug.Log("FIRE!");
			GameObject bullet = Instantiate(defaultProjectile, transform.position, transform.rotation);
			//assign its direction immediately after create
			bullet.GetComponent<ProjectileMotion>().mSpeed = projectileSpeed;
			bullet.GetComponent<ProjectileMotion>().direction = transform.rotation;

			Timer = 0.0f;
		}
	}

	private void setGunStats(){
		if (gameObject.tag == "Revolver"){
			projectileSpeed = 5f;
			rateOfFire = 3f;
			defaultProjectile = (GameObject)Resources.Load("RevolverProjectile");
		}
	}

	public void Fire(){

	}
}
