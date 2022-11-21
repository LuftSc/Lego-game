using System.Runtime.InteropServices;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteClick : MonoBehaviour
{
    private GameObject cubePrefab;
    private bool Choose = false;
    public void DelClick()
    {
        Choose = true;
    }

    private void Update() 
    {
        if (Choose && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Destroy(GetParametr(hit.transform));
                Choose = false;
            }
        }
    }
    private static GameObject GetParametr(Transform child){
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}
