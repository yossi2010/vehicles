using UnityEngine;
using System.Collections;

public class Accelerometer : MonoBehaviour {
    public Vector3 Accel=Vector3.zero,lastvel;
	public Rigidbody RbToMonitor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			if((RbToMonitor.velocity-lastvel)!=Vector3.zero) Accel=(RbToMonitor.velocity-lastvel)/Time.fixedDeltaTime;
	lastvel=RbToMonitor.velocity;
	}
}
