using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public WindZone windZone;

	public ParticleEmiter2D emiter;

	void OnDrawGizmos () {
		Gizmos.DrawIcon(transform.position,"wind_blowing_cloud.png", true);
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position, new Vector3(.25f, windZone.zoneHight, 0f));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


[System.Serializable]
public class WindZone{
	public float zoneHight;
	public AnimationCurve speedCurve;
}

[System.Serializable]
public class ParticleEmiter2D {
	public GameObject particle;
}