using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (AudioSource))]

public class Reactive : MonoBehaviour {

	public AudioClip hit;
	AudioSource audio;
	public Rigidbody _myRigidbody;
	public bool aSplode;

	private float crashTimer;
	private bool ableToCrash;

	private float timer;
	private float timerTarget = 0.5f;
	public bool explodable;
	public int charge;
	private float baseXZ = 1;
	private float baseY = 1f;
	private float baseMaxY = 5f;
	private float incrementXZ = 200f;
	private float incrementY = 200f;

	private float currentmass;
	private float lowestmass;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		crashTimer = 1f;
		baseXZ = baseXZ;
		explodable = true;
		timer = timerTarget;
		aSplode = false;
		_myRigidbody = GetComponent<Rigidbody> ();
		currentmass = _myRigidbody.mass;
	//	_myRigidbody.freezeRotation = true;
		//audio.rolloffMode(linear);
		gameObject.tag = "Explodable";
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!explodable) {
			timer -= Time.deltaTime;
			if(timer < 0){
				explodable = true;
				timer = timerTarget;
			}
		}

		if (aSplode) {
			float XZ = 1;
			float Y = 1;
			switch (charge){
			case 1:
				XZ = incrementXZ * 1f;
				Y = incrementY * 1;
				lowestmass = 25f;
				break;
				
			case 2:
				XZ = incrementXZ * 2f;
				Y = incrementY * 2f;
				lowestmass = 17f;
				break;
				
			case 3:
				XZ = incrementXZ * 3;
				Y = incrementY * 3;
				lowestmass = 5f;
				break;
				
			case 4:
				XZ = incrementXZ * 4;
				Y = incrementY * 4;
				lowestmass = 1f;
				break;
			}
			if(lowestmass < currentmass){
				currentmass = lowestmass;
				_myRigidbody.mass = currentmass;
			}
			Vector3 deadFly = new Vector3(Random.Range(-baseXZ - XZ, baseXZ + XZ),Random.Range(baseY + Y, baseMaxY + Y),Random.Range(-baseXZ - XZ, baseXZ + XZ));
			_myRigidbody.AddForce(deadFly);
			MetricManagerScript.pieceExplosions += 1;
			aSplode = false;
		}

		if (!ableToCrash) {
			crashTimer -= Time.deltaTime;
			if(crashTimer < 0){
				ableToCrash = true;
				crashTimer = 1f;
			}
		}

	
	}

	void OnCollisionEnter (Collision collision){
		
		if (collision.gameObject.tag == "Explodable" && ableToCrash) {
			if(collision.relativeVelocity.magnitude > 5){
			audio.pitch = Random.Range(0.8f, 1.2f);
			audio.PlayOneShot(hit);
				ableToCrash = false;
			}
		}
		
		if (collision.gameObject.tag == "Ground") {
			if(collision.relativeVelocity.magnitude > 5){
			audio.pitch = Random.Range(0.8f, 1.2f);
			audio.PlayOneShot(hit);
			}
		}
	}
}
