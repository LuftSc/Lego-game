using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class ClickToMoveButton : MonoBehaviour
{
    public static bool cubeMove;
    public GameObject MoveArrows;
    private Queue<GameObject> ArrowsQueue;

    public static void OnButtonClick()
    {
        cubeMove = true;
    }

    private void Awake()
    {
        ArrowsQueue = new Queue<GameObject>();
    }

    private void Update()
    {
        if (cubeMove && Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                MoveObject.isVisibleMoveArrows = true;
                cubeMove = false;
                var parent = GetParent(hit.transform);
                if (parent.CompareTag("MovementObj") && ArrowsQueue.Count < 1)
                {
                    var arrows = Instantiate(MoveArrows, parent.transform.position, Quaternion.identity);
                    ArrowsQueue.Enqueue(arrows);
                }
                else if (parent.CompareTag("MovementObj"))
                {
                    Destroy(ArrowsQueue.Dequeue());
                    var arrows = Instantiate(MoveArrows, parent.transform.position, Quaternion.identity);
                    ArrowsQueue.Enqueue(arrows);
                }
            }
        }
    }

    public static GameObject GetParent(Transform child)
    {
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}
