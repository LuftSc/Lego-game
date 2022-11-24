using System.Runtime.InteropServices;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Update = UnityEngine.PlayerLoop.Update;
using UnityEngine.UI;

public class DeleteClick : MonoBehaviour
{
    private GameObject cubePrefab;
    private bool Choose = false;
    public TextMeshProUGUI countTop;
    public TextMeshProUGUI countMedium;
    public TextMeshProUGUI countBottom;
    public Image fat_2x1_orange;
    public Image fat_2x2_orange;
    public Image fat_2x1_dark_orange;
    public Image fat_2x1_green;
    public TextMeshProUGUI countFirst;
    public TextMeshProUGUI countSecond;
    public TextMeshProUGUI countThird;

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
                var detale = GetParametr(hit.transform);
                if (detale.CompareTag("MovementObj"))
                {
                if (detale.name == "Lego-detail-fat_2x1_orange(Clone)")
                {
                    if (!fat_2x1_orange.gameObject.activeSelf)
                    {
                        fat_2x1_orange.gameObject.SetActive(true);
                        countTop.enabled = true;
                        countTop.text = "1";
                    }else countTop.text = (int.Parse(countTop.text) + 1).ToString();
                }
                else if (detale.name == "Lego-detail-fat_2x2_orange(Clone)")
                {
                    if (!fat_2x2_orange.gameObject.activeSelf)
                    {
                        fat_2x2_orange.gameObject.SetActive(true);
                        countTop.enabled = true;
                        countTop.text = "1";
                    }else countTop.text = (int.Parse(countTop.text) + 1).ToString();
                }
                else if (detale.name == "Lego-detail-fat_2x1_darkOrange(Clone)")
                {
                    if (!fat_2x1_dark_orange.gameObject.activeSelf)
                    {
                        fat_2x1_dark_orange.gameObject.SetActive(true);
                        countBottom.enabled = true;
                        countBottom.text = "1";
                    }else countBottom.text = (int.Parse(countBottom.text) + 1).ToString();
                }
                else if (detale.name == "Lego-detail-fat_2x1_green(Clone)")
                {
                    if (!fat_2x1_green.gameObject.activeSelf)
                    {
                        fat_2x1_green.gameObject.SetActive(true);
                        countMedium.enabled = true;
                        countMedium.text = "1";
                    }else countMedium.text = (int.Parse(countMedium.text) + 1).ToString();
                }
                Destroy(detale);
                Choose = false;
                }
                    //fat_2x1_orange.gameObject.SetActive(true);
                    //fat_2x2_orange.gameObject.SetActive(true);
                    //fat_2x1_dark_orange.gameObject.SetActive(true);
                    //countFirst.enabled = true;
                    //countSecond.enabled = true;
                    //countThird.enabled = true;
            }
        }
    }
    private static GameObject GetParametr(Transform child){
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}
