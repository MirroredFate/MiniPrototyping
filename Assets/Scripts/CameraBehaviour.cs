using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;
    

    [SerializeField] float heightOffset = 5f;
    [SerializeField] float cameraDistance = 3f;
    [SerializeField] float lerpSpeed = 0.5f;

    Vector3 cameraPosition;


    // Use this for initialization
    void Start () {
        transform.position = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position,new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance), lerpSpeed);
	}
}
