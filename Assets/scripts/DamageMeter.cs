using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageMeter : MonoBehaviour {


	public float startH;
	public Image greenBar;


	void Start (){
		startH = greenBar.rectTransform.rect.height;
	}


	void OnEnable()
	{
		BaloonMotor.OnHitEnemy += ApplyDamage;
	}
	
	
	void OnDisable()
	{
		BaloonMotor.OnHitEnemy -= ApplyDamage;
	}


	void ApplyDamage(float d){
		Debug.Log("DM");
		greenBar.rectTransform.sizeDelta = new Vector2(greenBar.rectTransform.rect.width,Mathf.Lerp(0f,startH,FlightInfo.health/100f));
	}
}
