using UnityEngine;
using System.Collections;

public class StarterBlock : MonoBehaviour {

	public GameObject BeamOfLight;
	public bool shrink;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (shrink && BeamOfLight != null) {
			BeamOfLight.transform.localScale -= new Vector3 (0.01f, 0.01f, 0.01f);
			if(BeamOfLight.transform.localScale.x < 0){
				Destroy (BeamOfLight);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			shrink = true;
		}
	}
}
