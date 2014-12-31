using UnityEngine;
using System.Collections;

public class BaloonCamera : MonoBehaviour {

	public Transform balloon;

	public float bottomLimit;

	public float xOffset;

	public float yOffset;

	private float yClamp;

	// Use this for initialization
	void Start () {
		xOffset = transform.position.x - balloon.position.x;
		yOffset = transform.position.y - balloon.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		yClamp = Mathf.Clamp(balloon.position.y + yOffset,bottomLimit,1000f);
		transform.position = new Vector3(balloon.position.x + xOffset, yClamp , -10f);
	}
}


