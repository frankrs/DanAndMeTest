using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedDist : MonoBehaviour {

	public Text text;
	

	void Update () {
		text.text = "Km/h: " + Mathf.RoundToInt(FlightInfo.speed * 3.6f);
	}
}
