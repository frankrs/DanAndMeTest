using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltMeter : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Meters: " + Mathf.RoundToInt(FlightInfo.altitude);
	}
}
