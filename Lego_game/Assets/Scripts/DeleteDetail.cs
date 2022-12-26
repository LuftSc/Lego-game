using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeleteDetail : MonoBehaviour
{
    public static bool goDelete;
    
    public static void OnClick()
    {
        goDelete = !goDelete;
    }

    private void Update()
    {
        if (goDelete && Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var detail = GetParent(hit.transform);
                if (detail.CompareTag("MovementObj"))
                {
                    var splitDetail = detail.name.Split("_");
                    var size = splitDetail[0].ToUpper();
                    var color = splitDetail[2].Split("(")[0].ToUpper();

                    foreach (var button in CreateButtons.NewButtons)
                    {
                        if (button.Size == size && button.Color == color)
                        {
                            var panel = gameObject.transform.parent.transform.parent.transform.GetChild(0).GetChild(0);
                            var btn = panel.Find($"{button.Prefab.name}(Clone)");
                            var count = btn.Find("count").GetComponent<TextMeshProUGUI>();
                            var amount = int.Parse(count.text[1].ToString());
                            count.text = $"x{amount + 1}";
                            count.transform.parent.gameObject.SetActive(true);
                        }
                    }
                    Destroy(detail);
                }
                goDelete = false;
            }
        }
    }
    private static GameObject GetParent(Transform child){
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}