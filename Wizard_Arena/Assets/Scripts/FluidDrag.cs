using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour
{
    [Range(1, 2f)]
    public float velocityExponent;   //[none]

    public float dragConstant;      

    private PhysicsEngine physicsEngine;
    // Use this for initialization
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocityVector = physicsEngine.velocituVector;
        float speed = velocityVector.magnitude;
        float dragSize = CalculateDrag(speed);
        Vector3 dragVector = dragSize *- velocityVector.normalized;

        physicsEngine.AddForce(dragVector);
    }


    float CalculateDrag(float speed)
    {

        float exponent = Mathf.Pow(speed, velocityExponent);
        float drag = dragConstant * exponent;
        return drag;
    }
}
