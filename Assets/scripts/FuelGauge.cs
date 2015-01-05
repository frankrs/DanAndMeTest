using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {

	public Image guage;
	private float startW;

	// Use this for initialization
	void Start () {
		startW = guage.rectTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		//guage.text = Mathf.Round(FlightInfo.fuel).ToString();
		guage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(0f,startW,FlightInfo.fuel/100),guage.rectTransform.rect.height);
	}
}
