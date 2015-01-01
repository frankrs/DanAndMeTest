using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltMeter : MonoBehaviour {

	public Text text;


	
	// Update is called once per frame
	void Update () {
		//var mAlt = Mathf.RoundToInt(FlightInfo.altitude * 10);
		//var altString = mAlt.ToString();
		//Debug.Log(altString);
		//var dec1 = (altString.Substring(0,1));
		//var dec2 = (altString.Substring(1,0));

		//text.text = "ALTITUDE: " + dec1  + "." + dec2;

		text.text = "ALTITUDE: " + Mathf.RoundToInt(FlightInfo.altitude);
	}
}
