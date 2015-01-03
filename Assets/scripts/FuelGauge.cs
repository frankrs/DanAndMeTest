using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {

	public Text guage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guage.text = Mathf.Round(FlightInfo.fuel).ToString();
	}
}
