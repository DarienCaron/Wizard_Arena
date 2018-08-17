using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour {

    public float magnusConstant = 1f;

    // ALWAYS GET A RIGIDBODY
    private Rigidbody rigidBody;
	// Use this for initialization
	void Start ()
    {
        //initialize the RigidBody
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // magnusConstant -> the constant of the magnus effect * Cross of the velocity (direction it is moving to) * the angular velocity (the rotation over itself)
        rigidBody.AddForce
        ( magnusConstant  *  Vector3.Cross(rigidBody.velocity, rigidBody.angularVelocity));
	}
}
