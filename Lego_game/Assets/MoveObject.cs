using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public static bool isVisibleMoveArrows;
    public GameObject MoveArrows;
    private void Update()
    {
        if (isVisibleMoveArrows)
        {
            //var arrowsPrefab = gameObject.transform.Find("Move-Arrows").gameObject;
            //var objPosition = gameObject.transform.localPosition;
            //var arrows = Instantiate(MoveArrows, objPosition, Quaternion.identity);
            //isVisibleMoveArrows = false;
            /*Debug.Log("before: " + arrows.activeSelf);
            arrows.SetActive(true);
            Debug.Log("after: " + arrows.activeSelf);
            isVisibleMoveArrows = false; */

        }
    }
}
