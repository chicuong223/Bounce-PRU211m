using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Location of the character
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if(playerTransform != null)
        {
            //store current position of the camera
            Vector3 tmp = transform.position;

            //set the camera's position x to the player's position x
            tmp.x = playerTransform.position.x;

            //set back the position of the camera to the tmp variable
            transform.position = tmp;
        }
    }
}
