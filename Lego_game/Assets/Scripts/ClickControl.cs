using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    public static GameObject cubePrefab;
    public static bool cubeChoosen;
    public static TextMeshProUGUI count;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cubeChoosen)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var objPos = hit.transform.position;
                var heightY = 0.0f;
                if (hit.transform.localScale.y < 1) heightY = hit.transform.localScale.y + 1.65f;
                else heightY = hit.transform.localScale.y;
                var pos = new Vector3(objPos.x, objPos.y + heightY, objPos.z);
                var newCube = Instantiate(cubePrefab, pos, Quaternion.identity);
                count.text = (int.Parse(count.text) - 1).ToString();
                cubeChoosen = false;
            }
        }
    }
}
