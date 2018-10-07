using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Playerpos;
	public float mSpeed;
	public float detectionDistance;
	public float audioDetectionDistance;
	public GameObject EnemyGun;
	private GameObject EnemyGunPrefab;


	public float chaseTimer;
	public float chaseMax;
	private GameObject Player;
	private PlayerMovement playerScript;
	private int layerMask;
	private int wallLayerMask;
	private float rayMax;
	private Vector3 playerLastSeen;
	private GameObject currentWeapon;

	// Use this for initialization
	void Start () {
		EnemyGunPrefab = (GameObject)Resources.Load("enemyGun");
		currentWeapon = Instantiate(EnemyGunPrefab, EnemyGun.gameObject.transform.position, EnemyGun.gameObject.transform.rotation,  gameObject.transform);
		currentWeapon.GetComponent<gunController>().mOwner = gameObject;


		Player = GameObject.FindGameObjectWithTag("Player");
		mSpeed = 3.5f;
		detectionDistance = 1.6f;
		audioDetectionDistance = 10f;

		// isChasing = false;
		chaseMax = 3.0f;
		rayMax = 4f;
		chaseTimer = chaseMax;
		playerScript = Player.GetComponent<PlayerMovement>();
		//layermaks for player
		layerMask = 1 << 8;
		wallLayerMask = 1 << 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MoveToPlayer(){
		float angle = AngleBetweenTwoPoints(transform.position, Player.gameObject.transform.position) - 90f;
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
		transform.position = Vector2.MoveTowards(transform.position, Player.gameObject.transform.position, mSpeed*Time.deltaTime);
	}

	void MoveToLastSeen()
	{
		float angle = AngleBetweenTwoPoints(transform.position, playerLastSeen) - 90f;
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
		transform.position = Vector2.MoveTowards(transform.position, playerLastSeen, mSpeed*Time.deltaTime);
	}


	void FixedUpdate(){
		chaseTimer+=Time.deltaTime;
		if (playerScript.isShooting){
			chaseTimer = 0;
		}
		if (isWithinDetectionRange() || chaseTimer < chaseMax){
			if (isWithinDetectionRange()){
				chaseTimer = 0f;
				MoveToPlayer();
			}
			else{
				MoveToLastSeen();
			}
		
		}
		Debug.DrawLine(transform.position, Player.gameObject.transform.position);


		
		// RaycastHit2D wallhit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector2.up), rayMax, wallLayerMask);

		// if (wallhit.collider = null){
		// 	Debug.Log(wallhit);
		// }

		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector2.up), rayMax, layerMask);
		if (hit.collider != null) {
			// float distance = Mathf.Abs(hit.point.y - transform.position.y);
			Debug.Log(hit.collider.tag);
			playerLastSeen = hit.transform.position;
			chaseTimer = 0;
			// Debug.Log(distance);
			if (hit.collider.tag == "Player")
			{
				currentWeapon.GetComponent<gunController>().setFire(true);
			}
			else{
				currentWeapon.GetComponent<gunController>().setFire(false);
			}
			Debug.DrawRay(transform.position, transform.TransformDirection(-Vector2.up) * rayMax, Color.red);
		}
	}

	bool isWithinDetectionRange(){
		// Debug.Log(Vector2.Distance(transform.position, Playerpos.position));
		return (Vector2.Distance(transform.position, Player.gameObject.transform.position) <= detectionDistance);

	}


	bool isWithinAudioDetectionRange(){
		// Debug.Log(Vector2.Distance(transform.position, Playerpos.position));
		return (Vector2.Distance(transform.position, Player.gameObject.transform.position) <= audioDetectionDistance);

	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		//get gradient in degrees
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
