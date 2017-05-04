using UnityEngine;
using System.Collections;

public class Accelerometer : MonoBehaviour {
    public Vector3 Accel=Vector3.zero,lastvel;
	public Rigidbody RbToMonitor;
	Transform myref;
	// Use this for initialization
	void Start () {
	myref=transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 locvel=myref.InverseTransformDirection(RbToMonitor.velocity);
			if((RbToMonitor.velocity-lastvel)!=Vector3.zero) Accel=(locvel-lastvel)/Time.fixedDeltaTime;
	lastvel=locvel;
	}
}
