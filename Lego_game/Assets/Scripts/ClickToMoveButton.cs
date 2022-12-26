using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

public class ClickToMoveButton : MonoBehaviour
{
    public static bool cubeMove;
    public GameObject MoveArrows;
    private Queue<GameObject> ArrowsQueue;
    public static bool isActive;
    public static List<Vector3> positionList;

    public static void OnButtonClick()
    {
        cubeMove = true;
        isActive = !isActive;
    }

    private void Awake()
    {
        ArrowsQueue = new Queue<GameObject>();
        positionList = new List<Vector3>();
    }

    private void Update()
    {
        if (!isActive && ArrowsQueue.Count > 0) Destroy(ArrowsQueue.Dequeue());
        if (cubeMove && Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                cubeMove = false;
                var parent = GetParent(hit.transform);
                var pos = GetCenterPosition(parent.transform);
                pos += new Vector3(0, 6, 0);
                if (parent.CompareTag("MovementObj") && ArrowsQueue.Count < 1)
                {
                    var allDetails = GameObject.FindGameObjectsWithTag("MovementObj");
                    foreach (var detail in allDetails)
                    {
                        var currentObj = parent.transform.position;
                        if (!currentObj.Equals(detail.transform.position))
                        {
                            
                            
                            positionList.Add(detail.transform.position);
                            //Debug.Log(new Vector3(3f, 4f, 5.1f).Equals(new Vector3(3f, 4f, 5f)));
                            //var resultVector3 = MathF.Abs(-5.1f) - MathF.Abs(5f);
                            //var exodus = resultVector3.x < 1 || resultVector3.y < 1 || resultVector3.z < 1;
                            //Debug.Log(resultVector3);
                        }
                    }
                    var arrows = Instantiate(MoveArrows, pos, Quaternion.identity);
                    ArrowsQueue.Enqueue(arrows);
                }
                else if (parent.CompareTag("MovementObj"))
                {
                    Destroy(ArrowsQueue.Dequeue());
                    
                    var allDetails = GameObject.FindGameObjectsWithTag("MovementObj");
                    Debug.Log($"allDetails {allDetails.Length}");
                    foreach (var detail in allDetails)
                    {
                        var currentObj = parent.transform.position;
                        if (!currentObj.Equals(detail.transform.position))
                        {
                           
                            positionList.Add(detail.transform.position);
                            //Debug.Log(new Vector3(3f, 4f, 5.1f).Equals(new Vector3(3f, 4f, 5f)));
                            //Debug.Log(new Vector3(3f, 4f, 5.1f) - new Vector3(3f,4f, 5f));
                        }
                    }
                    
                    var arrows = Instantiate(MoveArrows, pos, Quaternion.identity);
                    ArrowsQueue.Enqueue(arrows);
                }

                MoveObject.target = parent;
            }
        }
    }
    public static Vector3 GetCenterPosition(Transform detail)
    {
        var temp = detail.name.Split("x");
        var left = temp[0];
        var right = temp[1];
        var moveX = Convert.ToInt32(left[left.Length - 1].ToString()) - 1;
        var moveZ = Convert.ToInt32(right[0].ToString()) - 1;
        var pos = detail.position;
        return  new Vector3(pos.x + (1.45f * moveX), pos.y - 8.22f, pos.z + (1.73f * moveZ));
    }

    public static GameObject GetParent(Transform child)
    {
        while (child.parent != null) child = child.parent;
        return child.gameObject;
    }
}