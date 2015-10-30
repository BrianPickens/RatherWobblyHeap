using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public GameObject SoundMaker;
	public float growRate = 0.5f;
	public float explodeRate = 10f;
	public Transform _myTransform;
	public int charging;
	public int chargePower;

	// Use this for initialization

	void Start () {
		chargePower = 0;
		charging = 0;
		_myTransform = transform;
		SoundMaker = GameObject.FindWithTag ("SoundManager");
		transform.localScale = new Vector3 (10f,10f,10f);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (charging);
		if (charging == 0) {
			MeshRenderer renderer = GetComponent<MeshRenderer> ();
			Material material = renderer.material;
			Color color = renderer.material.color;
			color.a = 0.0f;
			renderer.material.color = color;
			gameObject.SetActive (false);
		} else if (transform.localScale.x > 3 && charging == 1) {
			MeshRenderer renderer = GetComponent<MeshRenderer> ();
			Material material = renderer.material;
			Color color = renderer.material.color;
			if (color.a < 0.6f) {
				color.a += 0.005f;
			}
			renderer.material.color = color;
            transform.Rotate(5, 5, 5);
            transform.localScale -= new Vector3 (growRate, growRate, growRate);
			if(transform.localScale.x < 10){
				chargePower = 1;
			}
			if(transform.localScale.x < 8){
				chargePower = 2;
			}
			if(transform.localScale.x < 6){
				chargePower = 3;
			}
			if(transform.localScale.x < 4){
				chargePower = 4;
			}
		} else if (transform.localScale.x < 10 && charging == 2) {
//			MeshRenderer renderer = GetComponent<MeshRenderer> ();
//			Material material = renderer.material;
//			Color color = renderer.material.color;
//			color.a = 0.5f;
//			renderer.material.color = color;
			transform.localScale += new Vector3 (explodeRate, explodeRate, explodeRate);

		}
		else {
            transform.Rotate(5, 5, 5);
            charging = 0;

		}


	}

	public void ResetSize(){
		transform.localScale = new Vector3 (10f, 20f, 10f);
	}

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Rabbit" && charging == 2)
        {
			if(other.gameObject.GetComponent<Enemy>().explodable){
			other.gameObject.GetComponent<Enemy>().explodable = false;
			other.gameObject.GetComponent<Enemy>().charge = chargePower;
			//SoundMaker.GetComponent<SoundManager>().HitOther();
			other.gameObject.GetComponent<Rigidbody>().mass = 1;
			other.gameObject.GetComponent<Enemy>().dead = true;
			other.gameObject.GetComponent<Enemy>().deadAnim = false;
			}
           // Destroy(other.gameObject);
        }

		if (other.gameObject.tag == "Explodable" && charging == 2) {
			if(other.gameObject.GetComponent<Reactive>().explodable){
			other.gameObject.GetComponent<Reactive>().explodable = false;
			other.gameObject.GetComponent<Reactive>().charge = chargePower;
			//SoundMaker.GetComponent<SoundManager>().HitOther();
			//other.gameObject.GetComponent<Rigidbody>().mass = 1;
			other.gameObject.GetComponent<Reactive>().aSplode = true;
			}

		}
		if(other.gameObject.tag == "Cow" && charging == 2)
		{
			//SoundMaker.GetComponent<SoundManager>().HitOther();
			//other.gameObject.GetComponent<Rigidbody>().mass = 1;
			other.gameObject.GetComponent<Cow>().deadAnim = false;
			// Destroy(other.gameObject);
		}

        if(other.gameObject.tag == "Grass" && charging == 2)
        {
            other.gameObject.GetComponent<GrassExplode>().GrassSplode();
        }

		if(other.gameObject.tag == "Chicken" && charging == 2)
		{
			if(other.gameObject.GetComponent<Chicken>().explodable){
				other.gameObject.GetComponent<Chicken>().explodable = false;
				other.gameObject.GetComponent<Chicken>().charge = chargePower;
				//SoundMaker.GetComponent<SoundManager>().HitOther();
				other.gameObject.GetComponent<Rigidbody>().mass = 1;
				other.gameObject.GetComponent<Chicken>().dead = true;
				other.gameObject.GetComponent<Chicken>().deadAnim = false;
			}
			// Destroy(other.gameObject);
		}

    }
}
