using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobcatArm : MonoBehaviour
{
    public ConfigurableJoint Arm;
    public HingeJoint loader, brackets;
    public float armpos = 0.05f,loaderpos=-15;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey("[8]")) armpos += 0.001f;
        if (Input.GetKey("[5]")) armpos -= 0.001f;
        if(armpos>0.52) armpos=0.52f;
        if(armpos<-0.1f) armpos=-0.1f;
        Arm.targetPosition = new Vector3(0, 0, armpos);
        if (Input.GetKey("[6]")) loaderpos += 0.1f;
        if (Input.GetKey("[3]")) loaderpos -= 0.1f;
        var temp=loader.spring;
        temp.targetPosition=loaderpos;
        loader.spring=temp;
    }
}
