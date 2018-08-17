using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour
{



    private PhysicEngineComplete[] physicsEngineArray;
    private const float particleToParticle = 6.673e-11f; // [kg m S^-2 M^2 kg^-2]
    // Use this for initialization
    void Start ()
    {
        physicsEngineArray = GameObject.FindObjectsOfType<PhysicEngineComplete>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        CalculateGravity();
    }


    void CalculateGravity()
    {
        foreach (PhysicEngineComplete physicsEngineA in physicsEngineArray)
        {
            foreach (PhysicEngineComplete physicsEngineB in physicsEngineArray)
            {
                //stops from applying forces to the same object twice, and stops the same object from applying force to itself
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {
                    Debug.Log("Calculating gravitional force exerted on" + physicsEngineA +
                              "Due to the gravity of " + physicsEngineB);
                    //gets the offset between A and B so it is possible to know the actual distance between A and B
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    //mathf.pow =Returns offset.magnitude raised to power 2f
                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitue = particleToParticle * physicsEngineA.mass * physicsEngineB.mass / rSquared;
                    Vector3 gravityFeltVector = gravityMagnitue * offset.normalized;

                    //remember that the force acts agaisnt the object, meaning that the result should be backwards (Negative)
                    physicsEngineA.AddForce(-gravityFeltVector);
                }
            }
        }
    }



}
