using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Vector3 _InitialPos; // Starting position of the player
    public float _YOffset;
    public Rigidbody rb;
    void Start()
    {
        _InitialPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < _YOffset)
        {
            Debug.Log("the object is under the limit");
            transform.position = _InitialPos;
        }


        if (Input.GetKeyDown("space"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 1, 0);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("w"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 0, 1);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("a"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(-1, 0, 0);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("s"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(0, 0, -1);
            print("space key was pressed");
        }
        if (Input.GetKeyDown("d"))
        {
            Vector3 tempVel = rb.velocity;
            rb.velocity = tempVel + new Vector3(1, 0, 0);
            print("space key was pressed");
        }
    }
}
