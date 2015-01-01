using UnityEngine;
using System.Collections;

public class BaloonMotor : MonoBehaviour {

	public BaloonControls controls;
	public Motor motor;


	private float startDist;


	void Start(){
		startDist = transform.position.x;
	}

	void Update () {
		// set static FlightInfo
		FlightInfo.altitude = transform.position.y;
		FlightInfo.distanceTraveled = transform.position.x - startDist;

	}
	

	void FixedUpdate () {

		FlightInfo.speed = transform.rigidbody2D.velocity.x;

		if(controls.gasOn){
			rigidbody2D.AddForce(new Vector2(0f,motor.gasPower));
		}
	}
}


[System.Serializable]
public class BaloonControls{
	public bool gasOn;
}

[System.Serializable]
public class Motor{
	public float gasPower;
}

public static class FlightInfo{
	public static float altitude;
	public static float distanceTraveled;
	public static float speed;
}