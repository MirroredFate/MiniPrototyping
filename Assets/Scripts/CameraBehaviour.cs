using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;

    PlayerMovement player;

    [SerializeField] float heightOffset = 5f;
    [SerializeField] float cameraSpeed = 5f;
    float cameraDistance;
    //[SerializeField][Range(0.1f, 2f)] float lerpSpeed = 0.5f;

    Vector3 cameraPosition;
    Vector3 offset;
    Vector3 playerPrevPos, playerMoveDir;

    void Start () {
        //transform.position = new Vector3(target.position.x, target.position.y + heightOffset, target.position.z - cameraDistance);
        offset = transform.position - target.transform.position;

        cameraDistance = offset.magnitude;
        playerPrevPos = target.transform.position;
        player = target.gameObject.GetComponent<PlayerMovement>();
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
        if(!player.IsMoving) { return; }
        playerMoveDir = target.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            transform.position = target.transform.position - playerMoveDir * cameraDistance;

            transform.position += new Vector3(0,heightOffset,0); // required height

            transform.LookAt(target.transform.position);

            playerPrevPos = target.transform.position;
        }
    }
}
