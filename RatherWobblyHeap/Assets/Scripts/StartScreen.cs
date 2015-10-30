using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			if(Application.loadedLevel == 0){
				MetricManagerScript.metrics.TimeStamp1();
				Application.LoadLevel (1);
			}

			else if(Application.loadedLevel == 1){
				MetricManagerScript.metrics.TimeStamp2();
				Application.LoadLevel (2);
			}

			else if(Application.loadedLevel == 2){
				MetricManagerScript.metrics.TimeStamp3();
				Application.LoadLevel (3);
			}
		}
	}
}
