using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTemporalScript : MonoBehaviour
{
    public Vector3 _InitialPos; // Starting position of the player
    public float _YOffset;
    public Rigidbody rb;
    void Start()
    {
        _InitialPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 10, 0);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("w"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 0, 10);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("a"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(-10, 0, 0);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("s"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 0, -10);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("d"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(10, 0, 0);
            print("space key was pressed");
        }
    }


    void FixedUpdate()
    {
        if (transform.position.y < _YOffset)
        {
            Debug.Log("the object is under the limit");
            transform.position = _InitialPos;
        }
    }
}
