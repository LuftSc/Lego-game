using System.Runtime.InteropServices;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Update = UnityEngine.PlayerLoop.Update;
using UnityEngine.UI;

public class FlipDetale : MonoBehaviour
{
    public GameObject cubeOrangeFlip;
    public GameObject cubeGreenFlip;
    public GameObject cubeDarkOrangeFlip;
    public GameObject cubeOrange;
    public GameObject cubeGreen;
    public GameObject cubeDarkOrange;
    private bool choose = false;

    public void ChooseClick()
    {
        choose = !choose;
    }

    void Update()
    {
        if (choose && Input.GetMouseButtonDown(0))
        { 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var detale = GetParametr(hit.transform);
                if (detale.CompareTag("MovementObj"))
                {
                    if (detale.name == "Lego-detail-fat_2x1_orange(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeOrangeFlip, pos, Quaternion.identity);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_darkOrange(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeDarkOrangeFlip, pos, Quaternion.identity);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_green(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeGreenFlip, pos, Quaternion.identity);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_orange_flip(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeOrange, pos, Quaternion.identity);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_darkOrange_flip(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeDarkOrange, pos, Quaternion.identity);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_green_flip(Clone)")
                    {
                        Destroy(detale);  
                        var objPos = hit.transform.position;
                        var heightY = 0.0f;
                        if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                        else heightY = hit.transform.localScale.y;
                        var pos = new Vector3(objPos.x, objPos.y, objPos.z);
                        var newCube = Instantiate(cubeGreen, pos, Quaternion.identity);
                    }
                    choose = false;
                }
            }
        }
    }
    private static GameObject GetParametr(Transform child)
    {
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}
