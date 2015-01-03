using UnityEngine;
using System.Collections;

public class PCControls : MonoBehaviour {

	public BaloonMotor bMotor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bMotor.controls.gasOn = Input.GetButton("Gas");
		bMotor.controls.bomb = Input.GetButtonDown("Bomb");
	}
}
