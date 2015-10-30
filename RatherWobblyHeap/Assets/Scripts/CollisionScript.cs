using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

	public AudioClip hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision){

//		foreach (ContactPoint contact in collision.contacts){
//			if(collision.gameObject.tag == "Ground"){
//				Debug.Log("weeeeee");
//			}
//			//Debug.Log("weeeeee");
//		//	Debug.DrawRay(contact.point, contact.normal, Color.red);
//
//		}

		if (collision.gameObject.tag == "Explodable") {
			GetComponent<AudioSource>().PlayOneShot(hit);
			Debug.Log ("weee");
		}

		if (collision.gameObject.tag == "Ground") {
			GetComponent<AudioSource>().PlayOneShot(hit);
			Debug.Log ("weee");
		}
	}
}
