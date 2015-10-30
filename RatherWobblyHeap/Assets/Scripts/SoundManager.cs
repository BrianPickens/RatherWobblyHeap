using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip Beam;
	public AudioClip Hit;
	public AudioClip Jump;
	public AudioClip Land;
	public AudioClip BeamRelease;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeSound(){

		this.GetComponent<AudioSource> ().PlayOneShot (Beam);
	}

	public void HitOther(){

		this.GetComponent<AudioSource> ().PlayOneShot (Hit);
	}

	public void CharJump(){

		this.GetComponent<AudioSource> ().PlayOneShot (Jump);
	}

	public void CharLand(){

		this.GetComponent<AudioSource> ().PlayOneShot (Land);
	}

	public void Release(){
		this.GetComponent<AudioSource> ().PlayOneShot (BeamRelease);
	}
	
}
