using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistMeter : MonoBehaviour {

	public Text text;
	
	// Update is called once per frame
	void Update () {
		text.text = "Distance: " + Mathf.RoundToInt(FlightInfo.distanceTraveled);
	}
}
