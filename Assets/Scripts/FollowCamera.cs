using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject target;
    public float damping = 1;


    public float cameraSpeed = 5f;
    Vector3 offset;


	// Use this for initialization
	void Start () {

        offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //getting Targets rotation and turn it into a rotation
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.RotateAround(target.transform.position, new Vector3(0,1,0), Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed);


        transform.LookAt(target.transform);
    }
}
