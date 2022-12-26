using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAroundM : MonoBehaviour
{
    public Transform Target;
    public float mouseSens = 2.5f;
    public float timer = 0.5f;
    public Camera mainCamera;
    public float zoom;
    

    public static bool changeTarget;
    public static Transform newTarget;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                float hor = Input.GetAxis("Mouse X");
                float ver = Input.GetAxis("Mouse Y");
                var pos = new Vector3();
                if (changeTarget) pos = newTarget.position;
                transform.RotateAround(Target.position, Vector3.up, hor * mouseSens * 300 * Time.deltaTime);
                //transform.RotateAround(newTarget.position, Vector3.up, hor * mouseSens * 300 * Time.deltaTime);
            }
        }
        else timer = 0.5f;

        if (Input.GetAxis("Mouse ScrollWheel") > 0) mainCamera.fieldOfView -= zoom; 
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) mainCamera.fieldOfView += zoom;
    }
}
