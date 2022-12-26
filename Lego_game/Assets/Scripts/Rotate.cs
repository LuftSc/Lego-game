using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float mouseSence = 2.5f;
    public Transform targetObj;
    public float rotationX;
    public float rotationY;
    public float cameraPositionZ;
    public float speedScrollCamera;
    public float minimumZ;
    public float maximumZ;
    public float minimumY;
    public float maximumY;
    public float minimumX;
    public float maximumX;
    public Vector3 tempPositionBot;

    public float tmpPositionY;
    public float tmpPositionZ;
    public Quaternion newRotation;
    public Vector3 newPosition;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Сохраняем значение осей мыши и умножаем на скорость вращения камеры
            // + и - отвечают за инверсию осей мыши
            rotationX += (Input.GetAxis("Mouse X") * (mouseSence));
            rotationY -= (Input.GetAxis("Mouse Y") * (mouseSence));
            //Приближаем камеру
            cameraPositionZ = Mathf.Clamp(cameraPositionZ + (Input.GetAxis("Mouse ScrollWheel") * speedScrollCamera), minimumZ, maximumZ);

            //Ограничиваем угол повора камеры по оси Y, если нужно
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            //Ограничиваем угол повора камеры по оси Y, если нужно
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
            //Определяем позицию обьекта, вокруг которого вращаемся
            tempPositionBot = new Vector3(targetObj.transform.position.x,
                targetObj.transform.position.y + tmpPositionY,//Здесь определяется точка фокуса камеры
                targetObj.transform.position.z);

            tmpPositionZ = cameraPositionZ * 0.1f;

            newRotation = Quaternion.Euler(rotationY, rotationX, 0f);
            newPosition = newRotation * new Vector3(0f, 0f, tmpPositionZ) + tempPositionBot;

            transform.rotation = newRotation;
            transform.position = newPosition;
        }
        }
        

    
}
