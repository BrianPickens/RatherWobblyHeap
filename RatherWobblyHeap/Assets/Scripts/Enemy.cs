using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Enemy : MonoBehaviour {

	public Transform Target;
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
	private float soundTimer;
	public AudioClip scaryLaugh;

	Animator anim;

	// Use this for initialization
	void Start () {
		explodable = true;
		anim = GetComponentInChildren<Animator> ();
        timer = timerTarget;
		gameObject.tag = "Rabbit";
		deadAnim = true;
		_myRigidbody = GetComponent<Rigidbody> ();
		_myTransform = transform;
		Target = null;
		soundTimer = Random.Range (2f,5f);

	}
	
	// Update is called once per frame
	void Update () {

		anim.SetFloat ("WalkDirection", _myRigidbody.velocity.z);


		if (Target != null && !dead) {
			soundTimer -=Time.deltaTime;
			if(soundTimer < 0){
				//GetComponent<AudioSource>().PlayOneShot(scaryLaugh);
				soundTimer = Random.Range (2f,5f);
			}
		//	Target.position = new Vector3 (Target.position.x, _myTransform.position.y, Target.position.z);
		//	_myTransform.LookAt(Target);
			_myTransform.position = Vector3.MoveTowards(_myTransform.position, Target.position, Time.deltaTime * speed);
		}

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
				_myRigidbody.mass = 100f;
            }
        }
	
	}

	public void SetTarget(){
		Target = GameObject.FindWithTag ("Player").transform;
		GetComponent<AudioSource>().PlayOneShot(scaryLaugh);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Damage") {
			Debug.Log ("Damage");
		}

	}
}
