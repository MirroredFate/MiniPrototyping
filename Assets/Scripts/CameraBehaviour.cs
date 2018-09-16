using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;
    [Range(0.1f,1f)]public float camDistance;

    [SerializeField] float heightOffset = 5f;
    [SerializeField] float cameraSpeed = 5f;


    float cameraDistance;
    //[SerializeField][Range(0.1f, 2f)] float lerpSpeed = 0.5f;

    PlayerMovement pm;
    Vector3 cameraPosition;
    Vector3 offset;
    Vector3 playerPrevPos, playerMoveDir;

    void Start () {
        //transform.position = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance);
        offset = transform.position - target.transform.position;
        pm = target.gameObject.GetComponent<PlayerMovement>();
        cameraDistance = offset.magnitude;
        playerPrevPos = target.transform.position;

    }

    private void Update()
    {
        transform.RotateAround(target.position, new Vector3(0, 1, 0), Input.GetAxis("HorizontalCamera") * Time.deltaTime * cameraSpeed);

    }


    void FixedUpdate () {
        //transform.position = Vector3.Lerp(transform.position,new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance), lerpSpeed);
      
    }


    void LateUpdate()
    {
        if (pm.isMoving)
        {
            playerMoveDir = target.transform.position - playerPrevPos;
            if (playerMoveDir != Vector3.zero)
            {
                playerMoveDir.Normalize();
                Vector3 targetPosition = target.transform.position - playerMoveDir * (cameraDistance * camDistance);
                transform.position = targetPosition; //camera moves behind player

                transform.position += new Vector3(0, heightOffset, 0); // required height

                transform.LookAt(target.transform.position); // camera looks at player

                playerPrevPos = target.transform.position;
            }
        }
        
    }
}
