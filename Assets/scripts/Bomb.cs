using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public Vector2 com;
	public WindZone windZone;
	private float altPercent;


	void OnDrawGizmos(){
		Gizmos.DrawSphere(transform.TransformPoint(com), 1);
	}

	// Use this for initialization
	void Start () {
		rigidbody2D.centerOfMass = com;
		windZone = GameObject.FindGameObjectWithTag("Wind").GetComponent<Wind>().windZone;
	}
	
	void Update (){
		altPercent = (transform.position.y - windZone.bottom)/windZone.zoneHight;
	}
	
	void FixedUpdate () {
		if(altPercent > 0){
			rigidbody2D.AddForce(new Vector2((windZone.speedCurve.Evaluate(altPercent)*.5f),0f));
		}
	}
}
