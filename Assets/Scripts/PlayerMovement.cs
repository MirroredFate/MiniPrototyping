using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool IsMoving 
    {
        get
        {
            return isMoving;
        }
    }

    public bool isMoving = false;
    public float speed = 5f;

    //public float speedMeUp = 4f;
    //float movementX;
    //float movementZ;
    Vector2 input;

    //Rigidbody rb;

    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {

        if (isMoving)
        {
            anim.SetBool("IsMoving", true);
        } else
        {
            anim.SetBool("IsMoving", false);
        }

        
        if (Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = Camera.main.transform.forward;
        Vector3 camR = Camera.main.transform.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF*input.y) * Time.deltaTime * speed;


        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);


    }


}
