using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public WindZone windZone;
	public FlightInfo flightInfo;

	public Transform balloon;

	void OnDrawGizmos () {
		Gizmos.DrawIcon(transform.position,"wind_blowing_cloud.png", true);
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position, new Vector3(.5f, windZone.zoneHight, 0f));
	}


	void Start () {
		windZone.bottom =  transform.position.y - (windZone.zoneHight/2);
		windZone.top = transform.position.y + (windZone.zoneHight/2);
	}

	void Update (){
		flightInfo.alt = balloon.position.y;
		flightInfo.altPercent = (flightInfo.alt - windZone.bottom)/windZone.zoneHight;
	}

	void FixedUpdate () {
		if(flightInfo.altPercent > 0){
		balloon.rigidbody2D.AddForce(new Vector2(windZone.speedCurve.Evaluate(flightInfo.altPercent),0f));
		}
	}
}


[System.Serializable]
public class WindZone{
	public float zoneHight;
	public float bottom;
	public float top;
	public AnimationCurve speedCurve;
}

[System.Serializable]
public class FlightInfo {
	public float alt;
	public float altPercent;
}