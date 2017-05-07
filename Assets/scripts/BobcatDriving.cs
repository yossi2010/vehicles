using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BobcatDriving : MonoBehaviour
{
    public HingeJoint[] LeftWheels, RightWheels;
    private float Throttle, Steering;
    public float Radius, Width, MaxRot, MaxSpeed;
    public bool ManualControl = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ManualControl)
        {
            Throttle = Input.GetAxis("Vertical");
            Steering = Input.GetAxis("Horizontal");
            DriveBobcat(Throttle, Steering);
        }
    }

    public void DriveBobcat(float throttle, float steering)
    {
        float LeftVel = throttle * MaxSpeed / Radius + (steering * MaxRot / Radius) * Width / 2;
        float RightVel = throttle * MaxSpeed / Radius - (steering * MaxRot / Radius) * Width / 2;
        LeftVel *= Mathf.Rad2Deg;
        RightVel *= Mathf.Rad2Deg;
        for (int i = 0; i < LeftWheels.Length; i++)
        {
            var tempmotor = RightWheels[i].motor;
            tempmotor.targetVelocity = RightVel;
            RightWheels[i].motor = tempmotor;
            tempmotor.targetVelocity = LeftVel;
            LeftWheels[i].motor = tempmotor;
        }
    }
}
