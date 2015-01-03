using UnityEngine;
using System.Collections;

public class BaloonCamera : MonoBehaviour {

	public Transform balloon;

	public float bottomLimit;
	public float lazy = .1f;

	public float startSize;
	public float sizeLimit;
	public float rightShiftComp;
	public float rightShiftCompMax;

	private float yOffset;
	private float xOffset;
	private float yClamp;

	// Use this for initialization
	void Start () {

		balloon  =  GameObject.FindGameObjectWithTag("Player").transform;

		xOffset = transform.position.x - balloon.position.x;
		yOffset = transform.position.y - balloon.position.y;

		startSize = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// get how far to shift the cam to the right to compensate for speed when zooming out
		rightShiftComp = Mathf.Lerp(0f,rightShiftCompMax,FlightInfo.speed/100);

		// clamp y so that he will land on the bottom
		yClamp = Mathf.Clamp(balloon.position.y + yOffset,bottomLimit,1000f);
		//transform.position = new Vector3(balloon.position.x + xOffset, yClamp , -10f);
		transform.position = Vector3.Lerp(transform.position,new Vector3(balloon.position.x + xOffset + rightShiftComp, yClamp , -10f),lazy);

		camera.orthographicSize = Mathf.Lerp(startSize,sizeLimit,FlightInfo.speed/100);
	}
}


