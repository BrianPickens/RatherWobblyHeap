using UnityEngine;
using System.Collections;

public class LockedCamera : MonoBehaviour {

	public Transform target;
	public float height;
	public float walkDistance;
	public float smoothTime = 0.3f;

	private Transform _myTransform;
	private Vector3 velocity = Vector3.zero;

	void Awake(){
		_myTransform = transform;
		target = GameObject.FindWithTag ("Target").GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
		CameraStart ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = target.TransformPoint (new Vector3 (0, height, walkDistance));
		_myTransform.position = Vector3.SmoothDamp (_myTransform.position, targetPosition, ref velocity, smoothTime);
        _myTransform.LookAt(target);
    }

	public void CameraStart(){
		_myTransform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - walkDistance);
		_myTransform.LookAt (target);
	}
}
