using System.Runtime.InteropServices;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Update = UnityEngine.PlayerLoop.Update;
using UnityEngine.UI;

public class FlipDetail : MonoBehaviour{
    public GameObject cubePrefab;
    public TextMeshProUGUI count;
    private bool Choose = false;

    public void ChooseClick()
    {
        Choose = true;
    }

    void Update()
    {
        if (Choose && Input.GetMouseButtonDown(0))
        { 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var detale = GetParametr(hit.transform);
                if (detale.CompareTag("MovementObj"))
                {
                    if (detale.name == "Lego-detail-fat_2x1_orange(Clone)")
                    {
                        Destroy(detale);
                    }
                    else if (detale.name == "Lego-detail-fat_2x2_orange(Clone)")
                    {
                        Destroy(detale);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_darkOrange(Clone)")
                    {
                        Destroy(detale);
                    }
                    else if (detale.name == "Lego-detail-fat_2x1_green(Clone)")
                    {
                        Destroy(detale);
                    }
                    Choose = false;
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
