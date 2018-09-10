using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool isMoving = false;
    public float speed = 10000f;
    float movementX;
    float movementZ;

    Rigidbody rb;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        movementX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movementZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.velocity = new Vector3(movementX, rb.velocity.y, movementZ);
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            isMoving = true;
        }

	}
}
