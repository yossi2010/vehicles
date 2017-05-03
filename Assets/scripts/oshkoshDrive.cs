using UnityEngine;
using System.Collections;

public class oshkoshDrive : MonoBehaviour {
	public float MaxSpeed=400,Speed,MaxSteeringAngle=0.4f,SteeringSpeed=0.3f;
	float steeringangle=0;
	public HingeJoint[] joints;
	public ConfigurableJoint[] steering;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	steeringangle=Mathf.Lerp(steeringangle,-MaxSteeringAngle*Input.GetAxis("Horizontal"),SteeringSpeed);
	Speed=MaxSpeed*Input.GetAxis("Vertical");
	for (int i = 0; i < joints.Length; i++)
	{
		var tempmotor=joints[i].motor;
		if(i<4)
		tempmotor.targetVelocity=Speed;
		else tempmotor.targetVelocity=-Speed;
		joints[i].motor=tempmotor;
	}
	for (int i = 0; i < steering.Length; i++)
	{
		var temp=steering[i].targetRotation;
		temp.z=steeringangle;
		temp.y=steeringangle;
		steering[i].targetRotation=temp;
	}
	}
	void OnTriggerEnter(){steeringangle=-0.45f;}

	void OnTriggerExit(){steeringangle=0;}
}
