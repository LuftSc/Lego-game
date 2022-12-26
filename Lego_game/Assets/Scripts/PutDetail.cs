using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

class Detail
{
    public Detail(GameObject GO)
    {
        name = GO.name;
        color = name.Split('_')[2].Split('(')[0];
        pos = GO.transform.position;
    }
    public string color;
    public static string name;
    public static Vector3 pos;
}
public class PutDetail : MonoBehaviour
{
    public GameObject cubePrefab;
    public TextMeshProUGUI count;
    public void OnClick() 
    {
        ClickControl.cubeChoosen = true;
        ClickToMoveButton.cubeMove = false;
        ClickControl.cubePrefab = cubePrefab;
        ClickControl.count = count;
    }
    public void Update()
    {
        if (count.text == "0")
        {
            count.text = "";
            count.enabled = false;
            gameObject.SetActive(false);
            var activeObjects = GameObject.FindGameObjectsWithTag("Detail");
            var isNotActiveObject = true;
            foreach (var obj in activeObjects)
            {
                if (obj.activeSelf)
                {
                    isNotActiveObject = false;
                    break;
                }
            }

            if (isNotActiveObject)
            {
                var allRight = CheckTruePlaceOfDetail();
                if (MoveToStep3.isCompleted) Debug.Log("!!!!!!!!!");
                else if (MoveToStep2.isCompleted) MoveToStep3.goToNextStep = true;
                else MoveToStep2.goToNextStep = true;
            }
                
        }
    }

    public bool CheckTruePlaceOfDetail()
    {
        var details = GameObject.FindGameObjectsWithTag("MovementObj");
        var dict = new Dictionary<string, Detail[]>();
        foreach (var detail in details)
        {
            Debug.Log(detail);
            var d = new Detail(detail);
            if (dict.ContainsKey(d.color))
            {
                dict[d.color] = dict[d.color].Union(new[] { d }).ToArray();
            }
            else dict[d.color] = new []{ d };
        }
        Debug.Log(dict);
        
        return true;
    }
}
