using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RotateCamera : MonoBehaviour
{
    public Camera cameraObj;
    public GameObject myGameObj;
    public float speed = 2f;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cameraObj.transform.RotateAround(myGameObj.transform.position,
                cameraObj.transform.up,
                -Input.GetAxis("Mouse X") * speed);

            cameraObj.transform.RotateAround(myGameObj.transform.position,
                cameraObj.transform.right,
                -Input.GetAxis("Mouse Y") * speed);
        }
    }
}

