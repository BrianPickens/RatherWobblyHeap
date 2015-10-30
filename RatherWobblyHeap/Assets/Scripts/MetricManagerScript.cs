using UnityEngine;
using System.Collections;
using System.IO;

public class MetricManagerScript : MonoBehaviour {

	string createText = "";
	public static MetricManagerScript metrics;
	[SerializeField]
	public static int cowFall;
	[SerializeField]
	public static int pieceExplosions;
	public int sampleMetric1, sampleMetric2;
	public float levelTimer;

	private float level1Time;
	private float level2Time;
	private float level3Time;

	void Awake(){
		Debug.Log ("I fired");
		if (metrics == null) {
			DontDestroyOnLoad (gameObject);
			metrics = this;
		} else if (metrics != this){
			Destroy(gameObject);
		}
	}

	void Start () {

		levelTimer = 0f;
	}
	void Update () {

		levelTimer += Time.deltaTime;

		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown ("X")) {
			sampleMetric1 += 1;
		}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown ("A")) {
			sampleMetric2 += 1;
		}

	}
	
	//When the game quits we'll actually write the file.
	void OnApplicationQuit(){
		GenerateMetricsString ();
		string time = System.DateTime.UtcNow.ToString ();string dateTime = System.DateTime.Now.ToString (); //Get the time to tack on to the file name
		time = time.Replace ("/", "-"); //Replace slashes with dashes, because Unity thinks they are directories..
		time = time.Replace (":", "_");
		string reportFile = "GameName_Metrics_" + time + ".txt"; 
		File.WriteAllText (reportFile, createText);
		//In Editor, this will show up in the project folder root (with Library, Assets, etc.)
		//In Standalone, this will show up in the same directory as your executable
	}

	void GenerateMetricsString(){
		createText = 
			"Number of times Jump: " + sampleMetric1 + "\n" +
			"Number of times Used Power: " + sampleMetric2 + "\n" + 
			"Number of Cows Tipped: " + cowFall + "\n" +
			"Number of Pieces Exploded: " + pieceExplosions + "\n" +
			"Start Time: " + level1Time + "\n" +
			"Tutorial Time: " + level2Time + "\n" +
			"Hub Time: " + level3Time + "\n";
	}

	//Add to your set metrics from other classes whenever you want
	public void AddToSample1(int amtToAdd){
		sampleMetric1 += amtToAdd;
	}

	public void TimeStamp1(){
		level1Time = levelTimer;
		levelTimer = 0f;
	}
	public void TimeStamp2(){
		level2Time = levelTimer;
		levelTimer = 0f;
	}
	public void TimeStamp3(){
		level3Time = levelTimer;
		levelTimer = 0f;
	}
}
