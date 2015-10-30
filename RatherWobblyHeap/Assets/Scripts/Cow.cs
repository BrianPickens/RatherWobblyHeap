using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Cow : MonoBehaviour {

	public AudioClip Moo;
	public AudioClip AngryMoo;
	public AudioClip DownMoo;
	public Transform _myTransform;
	public Rigidbody _myRigidbody;
	//public bool dead;
	public bool deadAnim = true;
	public float minXZ = -400f;
	public float maxXZ = 400f;
	public float minY = 200f;
	public float maxY = 400f;
	private float timer;
	private bool down;

	public Transform GroundCheck;
	public float groundRadius = 0.2f;
	public LayerMask WhatisGround;

	// Use this for initialization
	void Start () {
		gameObject.tag = "Cow";
		deadAnim = true;
		_myRigidbody = GetComponent<Rigidbody> ();
		_myTransform = transform;
		timer = Random.Range (4f, 10f);
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
	
		Collider[] hitColliders = Physics.OverlapSphere (GroundCheck.position, groundRadius, WhatisGround);
		int i = 0;
		
		if (i < hitColliders.Length) {
			if(!down){
				down = true;
				GetComponent<AudioSource>().pitch = Random.Range (0.9f, 1.1f);
				GetComponent<AudioSource>().PlayOneShot(AngryMoo);
				MetricManagerScript.cowFall += 1;
			}
			if(timer < 0){
				GetComponent<AudioSource>().pitch = Random.Range (0.9f, 1.1f);
				GetComponent<AudioSource>().PlayOneShot(DownMoo);
				timer = Random.Range (4f, 10f);
			}
		} else {
			if (timer < 0) {
				GetComponent<AudioSource>().pitch = Random.Range (0.9f, 1.1f);
				GetComponent<AudioSource>().PlayOneShot(Moo);
				timer = Random.Range (4f, 10f);
			}
		}







		if (!deadAnim) {
			Vector3 deadFly = new Vector3(Random.Range(minXZ,maxXZ),Random.Range(minY, maxY),Random.Range(minXZ,maxXZ));
			_myRigidbody.AddForce(deadFly);
			deadAnim = true;
		}
	}
}
