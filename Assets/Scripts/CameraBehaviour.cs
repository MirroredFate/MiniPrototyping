using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;

    [SerializeField] float heightOffset = 5f;
    [SerializeField] float cameraDistance = 3f;

    Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
        cameraPosition = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance);
        transform.position = cameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = cameraPosition;
	}
}
