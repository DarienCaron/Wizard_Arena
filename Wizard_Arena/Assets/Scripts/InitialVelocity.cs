using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
     //TEST FUNCTION!!!
     //use this function to give velocities or initialize values to test other functions
    
    //Put any value here that you wish to initiliaze or keep track of (there is another function that already keeps track of velocities.)
    public Vector3 initialVelocity;
    public Vector3 initialW;

    //
    private Rigidbody rigidBody;
	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = initialVelocity;
        rigidBody.angularVelocity = initialW;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
