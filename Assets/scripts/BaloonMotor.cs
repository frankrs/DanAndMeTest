using UnityEngine;
using System.Collections;

public class BaloonMotor : MonoBehaviour {

	public BaloonControls controls;
	public Motor motor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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