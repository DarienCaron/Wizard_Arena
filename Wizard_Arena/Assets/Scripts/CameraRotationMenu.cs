using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationMenu : MonoBehaviour
{

    public GameObject targetToFollow = null;
    public bool yOrbit = false;

    //REMEMBER pkay around with the numbers to find the perfect spot....then make them private or local
    public float A = 3;
    public float B = 30;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
		if(targetToFollow != null)
        {
            transform.LookAt(targetToFollow.transform);
            if(yOrbit)
            {

                //rotation around the object
                transform.RotateAround(targetToFollow.transform.position, Vector3.up, Time.deltaTime*9.8f);


                Vector3 pos = transform.position;
                transform.position = pos + new Vector3(0.0f, Mathf.Sin(Time.time/A) / B, 0.0f);
                //Vector3 pos = transform.position;
                ////going up and down
                //float newY = Mathf.Sin(Time.time); 
                //transform.position = new Vector3(pos.x, pos.y+ newY, pos.z);
                //quit screen
                //float newY = Mathf.Sin(Time.time) * Mathf.Tan(Time.time);
            }
        }
	}
}
