using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	void OnEnable()
	{
		BaloonMotor.OnHitEnemy += ApplyDamage;
	}
	
	
	void OnDisable()
	{
		BaloonMotor.OnHitEnemy -= ApplyDamage;
	}


	public void ApplyDamage (float d){
		FlightInfo.health = FlightInfo.health - d;
		Debug.Log(FlightInfo.health);
	}

}
