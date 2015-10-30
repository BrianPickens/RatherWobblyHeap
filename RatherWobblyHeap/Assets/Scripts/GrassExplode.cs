using UnityEngine;
using System.Collections;

public class GrassExplode : MonoBehaviour {

    public GameObject GrassTop;
    public GameObject GrassBottom;
    public GameObject Explode;
    private bool hit;
    private float timer = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (hit)
        {
            timer -= Time.deltaTime;
            if( timer < 0){
				gameObject.tag = "Untagged";
				Explode.SetActive(false);
                } 
        }

	}

    public void GrassSplode()
    {
        if (!hit) { 
         GrassTop.SetActive(false);
         GrassBottom.SetActive(false);
         Explode.SetActive(true);
		 
         hit = true;
        }
    }
}
