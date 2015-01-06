using UnityEngine;
using System.Collections;

public class BaloonMotor : MonoBehaviour {


	public delegate void HitEnemy(float f);
	public static event HitEnemy OnHitEnemy;


	public BaloonControls controls;
	public Motor motor;
	public BombBay bombBay;

	private float startDist;


	void Start(){
		startDist = transform.position.x;
	}

	void Update () {
		// set static FlightInfo
		FlightInfo.altitude = transform.position.y;
		FlightInfo.distanceTraveled = transform.position.x - startDist;


		// drop bombs if theres a signal
		if(controls.bomb){
			BombsAway();
		}
	}




	void BombsAway (){
		var b = GameObject.Instantiate(bombBay.loadedBomb,new Vector3(transform.position.x,transform.position.y - 20f,transform.position.z),Quaternion.identity) as GameObject;
		b.rigidbody2D.velocity = gameObject.rigidbody2D.velocity;
	}

	void OnCollisionEnter2D (Collision2D col){
		DontHit dh = col.collider.GetComponent<DontHit>();
		if (dh != null){
			OnHitEnemy(dh.damage);
			dh.Die ();
		}
	}



	void FixedUpdate () {

		FlightInfo.speed = transform.rigidbody2D.velocity.x;

		if(controls.gasOn){
			// opt out if out of gas
			if(FlightInfo.fuel <= 0){
				return;
			}
			// burn fuel
			FlightInfo.fuel = FlightInfo.fuel - (motor.burnRate * Time.fixedDeltaTime);

			//apply force from gas
			rigidbody2D.AddForce(new Vector2(0f,motor.gasPower));
		}
	}
}


[System.Serializable]
public class BaloonControls{
	public bool gasOn;
	public bool bomb;
}

[System.Serializable]
public class Motor{
	public float gasPower;
	public float burnRate = 20f;
}

[System.Serializable]
public class BombBay{
	public GameObject loadedBomb;
}



public static class FlightInfo{
	public static float altitude;
	public static float distanceTraveled;
	public static float speed;
	public static float fuel = 100f;
	public static float health = 100f;
}


