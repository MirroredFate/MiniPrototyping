using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool isMoving = false;
    float movementX;
    float movementZ;

    Rigidbody rb;

    float speed = 10f;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        movementX = Input.GetAxis("Horizontal") * speed;
        movementZ = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector3(movementX, rb.velocity.y, movementZ);


        if(rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
	}
}
