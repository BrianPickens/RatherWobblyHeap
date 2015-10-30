using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Chicken : MonoBehaviour {

	//public Transform Target;
	public float speed = 5f;
	public Transform _myTransform;
	public Rigidbody _myRigidbody;
	public bool dead;
	public bool deadAnim = true;
	public float baseXZ = 400f;
	public float baseY = 200f;
	public float baseMaxY = 400f;
	public float incrementXZ = 200f;
	public float incrementY = 200f;
	private float timer;
	public float timerTarget;
	public bool explodable;
	public int charge;
	public AudioClip chickenChirp;
	private float jumpTimer;



	//private Transform _myTransform;
	//private Rigidbody _myRigidbody;
	//private Vector3 _targetVector;
	//private float speed = 10f;
	//private float timer = 0.2f;
	//private bool arrived;
	//private float travelTimer = 2f;

	// Use this for initialization
	void Start () {
		_myRigidbody = GetComponent<Rigidbody> ();
		_myTransform = transform;
	//	_targetVector = new Vector3(_myTransform.position.x + Random.Range (-5f,5f),_myTransform.position.y, _myTransform.position.z + Random.Range (-5f,5f));
		jumpTimer = Random.Range (2f, 4f);
		explodable = true;
		timer = timerTarget;
		gameObject.tag = "Chicken";
		deadAnim = true;
		_myRigidbody = GetComponent<Rigidbody> ();
		_myTransform = transform;
		//Target = null;

	}
	
	// Update is called once per frame
	void Update () {

		_myTransform.LookAt (Camera.main.transform);

		jumpTimer -= Time.deltaTime;
		if (jumpTimer < 0) {
			//_myRigidbody.AddForce(Vector3.up * 150f);
			_myRigidbody.velocity = new Vector3(0,4f,0);
			GetComponent<AudioSource>().PlayOneShot(chickenChirp);
			jumpTimer = Random.Range (2f,4f);
		}
//		if (Target != null && !dead) {
			//	Target.position = new Vector3 (Target.position.x, _myTransform.position.y, Target.position.z);
			//	_myTransform.LookAt(Target);
			//_myTransform.position = Vector3.MoveTowards(_myTransform.position, Target.position, Time.deltaTime * speed);
//		}
		
		if (!deadAnim) {
			float XZ = 1;
			float Y = 1;
			switch (charge){
			case 1:
				XZ = incrementXZ * 1;
				Y = incrementY * 1;
				//incrementY = 
				break;
				
			case 2:
				XZ = incrementXZ * 2;
				Y = incrementY * 2;
				break;
				
			case 3:
				XZ = incrementXZ * 3;
				Y = incrementY * 3;
				break;
				
			case 4:
				XZ = incrementXZ * 4;
				Y = incrementY * 4;
				break;
			}
			Vector3 deadFly = new Vector3(Random.Range(-baseXZ - XZ, baseXZ + XZ),Random.Range(baseY + Y, baseMaxY + Y),Random.Range(-baseXZ - XZ, baseXZ + XZ));
			_myRigidbody.AddForce(deadFly);
			deadAnim = true;
		}
		
		if (dead && deadAnim)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				dead = false;
				timer = timerTarget;
				explodable = true;
			}
		}


//		if (_myTransform.position == _targetVector) {
//				timer -= Time.deltaTime;
//				if(timer < 0){
//				Debug.Log ("normal");
//				_targetVector = new Vector3(_myTransform.position.x + Random.Range (-5f,5f),_myTransform.position.y, _myTransform.position.z + Random.Range (-5f,5f));
//				travelTimer = 2f;
//				timer = 0.2f;
//				}
//		} 
//
//		else{
//			travelTimer -= Time.deltaTime;
//			_myTransform.position = Vector3.MoveTowards (_myTransform.position, _targetVector, Time.deltaTime * speed);
//			if(travelTimer < 0){
//				Debug.Log ("save");
//				_targetVector = new Vector3(_myTransform.position.x + Random.Range (-5f,5f),_myTransform.position.y, _myTransform.position.z + Random.Range (-5f,5f));
//				travelTimer = 2f;
//				timer = 0.2f;
//			}
//		}


	}

}
