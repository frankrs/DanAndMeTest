using UnityEngine;
using System.Collections;

public class DontHit : MonoBehaviour {

	public float damage;

	public void Die (){
		Destroy(gameObject);
	}
}


