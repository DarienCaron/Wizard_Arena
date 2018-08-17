using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhysicsEngine : MonoBehaviour
{
    // [is to have a description in unity while the mopuse is over this]
    [Tooltip("KG")]
    public float mass; // KG
    [Tooltip("[ m s^-1]")]
    public Vector3 velocituVector; //[m*s^-1]
    public Vector3 netForceVector;// N [kg m s^-2]
    public float terminalVelocity;

    private List<Vector3> forceVectorList = new List<Vector3>();

    // Use this for initialization
    void Start ()
    {
        SetUpDrawForces();


    }
	
	// Update is called once per frame
	void Update ()
    {
	}
     void FixedUpdate()
    {
        RenderForces();
        UpdatePosition();
    }

    public void AddForce(Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
        //Debug.Log("Adding force" + forceVector + " to " + gameObject);
    }
    

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
        Debug.Log("accelerationVector: " + accelerationVector);


        Vector3 DeltaS = Vector3.ClampMagnitude(velocituVector, 10) * Time.deltaTime;
        transform.position += DeltaS;
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
