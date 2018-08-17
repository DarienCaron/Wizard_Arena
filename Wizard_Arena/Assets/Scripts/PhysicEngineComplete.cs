using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicEngineComplete : MonoBehaviour
{
    //physic engine
    // [is to have a description in unity while the mopuse is over this]
    [Tooltip("KG")]
    public float mass; // KG
    [Tooltip("[ m s^-1]")]
    public Vector3 velocituVector; //[m*s^-1]
    public Vector3 netForceVector;// N [kg m s^-2]


    private List<Vector3> forceVectorList = new List<Vector3>();


    //FluidDrag
    [Range(1, 2f)]
    public float velocityExponent;   //[none]
    public float dragConstant;
    private PhysicEngineComplete physicsEngine;

    //MagnusEffect
    public float magnusConstant = 1f;

    // ALWAYS GET A RIGIDBODY
    private Rigidbody rigidBody;
    // Use this for initialization

    // Use this for initialization
    void Start()
    {
        //physic engine
        SetUpDrawForces();

        //FluidDrag
        physicsEngine = GetComponent<PhysicEngineComplete>();

        //MagnusEffect
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        //physic engine
        RenderForces();
        UpdatePosition();

        //FluidDrag
        Vector3 velocityVector = physicsEngine.velocituVector;
        float speed = velocityVector.magnitude;
        float dragSize = CalculateDrag(speed);
        Vector3 dragVector = dragSize * -velocityVector.normalized;

        physicsEngine.AddForce(dragVector);
        //MagnusEffect
        // magnusConstant -> the constant of the magnus effect * Cross of the velocity (direction it is moving to) * the angular velocity (the rotation over itself)
        rigidBody.AddForce
        (magnusConstant * Vector3.Cross(rigidBody.velocity, rigidBody.angularVelocity));


    }

    public void AddForce(Vector3 forceVector)
    {
        //physic engine
        forceVectorList.Add(forceVector);
        Debug.Log("Adding force" + forceVector + " to " + gameObject);
    }

    //physic engine
    void UpdatePosition()
    {
        //remember that the gravity is calculate somewhere else for easy debbuging
        //sum the forces and clear the list
        netForceVector = Vector3.zero;

        foreach (Vector3 forceVector in forceVectorList)
        {
            netForceVector = netForceVector + forceVector;
        }
        forceVectorList = new List<Vector3>();

        //calculate the position change due to net force

        Vector3 accelerationVector = netForceVector / mass;
        velocituVector += accelerationVector * Time.deltaTime;

        //clamp the velocity so objects that are being atract to the ground dont pass throughg items, or objects that are going at high speed dont pass through things.
        Vector3 DeltaS = Vector3.ClampMagnitude(velocituVector, 27.5f) * Time.deltaTime;
        transform.position += DeltaS;
    }

    //FluidDrag
    float CalculateDrag(float speed)
    {

        float exponent = Mathf.Pow(speed, velocityExponent);
        float drag = dragConstant * exponent;
        return drag;
    }

    //DEBUG DRAW FORCES
    //VARIABLES FOR THE DEBBUG HERE!!!

    public bool showForces = true;
    private LineRenderer lineRenderer;
    private int numberOfForces;

    // Use this for initialization
    void SetUpDrawForces()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.2F;
        lineRenderer.endWidth = 0.2F;
        lineRenderer.useWorldSpace = false;
    }

    // Update is called once per frame
    void RenderForces()
    {
        if (showForces)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.positionCount = (numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }




}
