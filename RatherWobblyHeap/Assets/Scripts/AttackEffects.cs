using UnityEngine;
using System.Collections;

public class AttackEffects : MonoBehaviour {


    public Transform _myTransform;
    public float growRate = 0.5f;
    public float explodeRate = 10f;
    public bool charging;
	public int chargeCount;

    // Use this for initialization
    void Start () {
        _myTransform = transform;
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		Material material = renderer.material;
		Color color = renderer.material.color;
		color.a = 0.0f;
		renderer.material.color = color;
        transform.localScale = new Vector3(10f, 10f, 10f);
		chargeCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!charging)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Material material = renderer.material;
            Color color = renderer.material.color;
            color.a = 0.0f;
            renderer.material.color = color;
            _myTransform.localScale = new Vector3(10f, 10f, 10f);
        }
		else if (charging  && chargeCount < 2)
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Material material = renderer.material;
            Color color = renderer.material.color;
            if (color.a < 0.4f)
            {
                color.a += 0.01f;
            }
            renderer.material.color = color;
            transform.Rotate(5, 5, 5);
            transform.localScale -= new Vector3(growRate, growRate, growRate);
            if(_myTransform.localScale.x < 1){
				chargeCount += 1;
                LocalResetSphere();
            }
        }
    }

    public void ResetSphere()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Material material = renderer.material;
        Color color = renderer.material.color;
        color.a = 0.0f;
        renderer.material.color = color;
        _myTransform.localScale = new Vector3(10f, 10f, 10f);
		chargeCount = 0;
        gameObject.SetActive(false);
    }

    public void LocalResetSphere(){
		if (chargeCount < 2) {
			MeshRenderer renderer = GetComponent<MeshRenderer> ();
			Material material = renderer.material;
			Color color = renderer.material.color;
			color.a = 0.0f;
			renderer.material.color = color;
			_myTransform.localScale = new Vector3 (10f, 10f, 10f);
		}
    }
}
