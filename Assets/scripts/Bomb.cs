using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public Vector2 com;
	private WindZone windZone;
	private float altPercent;
	public GameObject fin;
	private GameObject thisFin;
	public GameObject explosion;
	public LayerMask layerMask;
	public float blastRadius;
	public float blastPower;
	//private Collider2D[] targets;

	void OnDrawGizmos(){
		Gizmos.DrawSphere(transform.TransformPoint(com), 1);
	}

	// Use this for initialization
	void Start () {
		rigidbody2D.centerOfMass = com;
		windZone = GameObject.FindGameObjectWithTag("Wind").GetComponent<Wind>().windZone;

		// create fin if needed
		thisFin = GameObject.Instantiate(fin,transform.position,Quaternion.identity) as GameObject;
		thisFin.GetComponent<HingeJoint2D>().connectedBody = rigidbody2D;
	}
	
	void Update (){
		altPercent = (transform.position.y - windZone.bottom)/windZone.zoneHight;
	}
	
	void FixedUpdate () {
		if(altPercent > 0){
			rigidbody2D.AddForce(new Vector2((windZone.speedCurve.Evaluate(altPercent)*.5f),0f));
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		// get point of impact
		var impact = col.contacts[0].point;
		// draw expolsion
		var explode = GameObject.Instantiate(explosion,impact,Quaternion.identity) as GameObject;
		// get targets hit
		Collider2D[] targets = Physics2D.OverlapCircleAll(impact,blastRadius);
		// add blast force
		if (targets != null){
			foreach(Collider2D c in targets){
				// check if has rigidbody
				if(c.rigidbody2D){
					// add blast
					c.rigidbody2D.AddForceAtPosition(new Vector2(blastPower,blastPower),impact,ForceMode2D.Impulse);
				}
			}
		}
		// destroy left over
		Destroy(thisFin);
		Destroy(gameObject);
	}
}
