using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameBlocks : MonoBehaviour {

	private static bool yellow;
	private static bool red;
	public static bool blue;
	Collider2D myCollider;
	string tag; 

	void Awake()
	{
		yellow = red = blue = false;
	}

	void Update()
	{
		if (yellow == true && red == true && blue == true){
			Debug.Log("NEXT SCENE");
		}
	}

	void Start(){
		myCollider =  this.GetComponent<Collider2D>();
		tag = gameObject.tag;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log(tag);
		if (collision.gameObject.tag == "blue" && tag == "blueEndGate"){
			Vector3 bluePos = collision.transform.position;
			Vector3 rightSide = bluePos;
			rightSide.x += collision.transform.localScale.x;
			Vector3 leftSide = bluePos;
			leftSide.x -= collision.transform.localScale.x;
			float left = this.GetComponent<Collider2D>().bounds.SqrDistance(leftSide);
			float right = this.GetComponent<Collider2D>().bounds.SqrDistance(rightSide);
			if (left <= 0.55f && right <= 0.55f){
				blue = true;
			}
			else{
				blue = false;
			}
	 
		}
		if (collision.gameObject.tag == "red" && tag == "redEndGate"){
			Vector3 redPos = collision.transform.position;
			Vector3 rightSide = redPos;
			rightSide.x += collision.transform.localScale.x;
			Vector3 leftSide = redPos;
			leftSide.x -= collision.transform.localScale.x;
			float left = this.GetComponent<Collider2D>().bounds.SqrDistance(leftSide);
			float right = this.GetComponent<Collider2D>().bounds.SqrDistance(rightSide);
			if (left <= 1.20 && right <= 1.20f){
				red = true;
			}
			else{
				red = false;
			}
	 
		}
		if (collision.gameObject.tag == "yellow" && tag == "yellowEndGate"){
			Vector3 yellowPos = collision.transform.position;
			Vector3 rightSide = yellowPos;
			rightSide.x += collision.transform.localScale.x;
			Vector3 leftSide = yellowPos;
			leftSide.x -= collision.transform.localScale.x;
			float left = this.GetComponent<Collider2D>().bounds.SqrDistance(leftSide);
			float right = this.GetComponent<Collider2D>().bounds.SqrDistance(rightSide);

			if (left <= 1.30 && right <= 1.30f){
				yellow = true;
			}
			else{
				yellow = false;
			}
	 
		} 
		
	}

}
