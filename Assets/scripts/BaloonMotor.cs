using UnityEngine;
using System.Collections;

public class BaloonMotor : MonoBehaviour {

	public BaloonControls controls;
	public Motor motor;


	void Update () {
		// set static FlightInfo
		FlightInfo.altitude = transform.position.y;
	}
	

	void FixedUpdate () {
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
}