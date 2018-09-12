using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool isMoving = false;
    public float speed = 5f;
    //public float speedMeUp = 4f;
    //float movementX;
    //float movementZ;
    Vector2 input;

    //Rigidbody rb;
    
    // TODO Cloud ParticleSystem relative to movement
    ParticleSystem pS;
    ParticleSystem.EmissionModule pSE;
    ParticleSystem.Burst burst;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        pS = GetComponentInChildren<ParticleSystem>();
        pSE = pS.emission;
        
	}
	
	// Update is called once per frame
	void Update () {
        //movementX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //movementZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //rb.velocity = new Vector3(movementX, rb.velocity.y, movementZ);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = Camera.main.transform.forward;
        Vector3 camR = Camera.main.transform.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF*input.y + camR*input.x) * Time.deltaTime * speed;

        if (isMoving)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        }

        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, -90, 0);
        //}

        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 90, 0);
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}

        //if ((Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow))))
        //{
        //     transform.eulerAngles = new Vector3(0, 225, 0);
        //}

        //if ((Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightArrow))))
        //{
        //    transform.eulerAngles = new Vector3(0, 135, 0);
        //}

        //if ((Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow))))
        //{
        //    transform.eulerAngles = new Vector3(0, 325, 0);
        //}

        //if ((Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightArrow))))
        //{
        //    transform.eulerAngles = new Vector3(0, 45, 0);
        //}

        if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


    }


}
