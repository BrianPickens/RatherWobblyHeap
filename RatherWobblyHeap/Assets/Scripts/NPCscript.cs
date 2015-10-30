using UnityEngine;
using System.Collections;

public class NPCscript : MonoBehaviour {

//	public GameObject Dialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){

		if(Input.GetKeyDown(KeyCode.Space)){
			if (other.gameObject.tag == "Player") {
		//		Dialogue.SetActive (true);
			}
		}
	}

}
