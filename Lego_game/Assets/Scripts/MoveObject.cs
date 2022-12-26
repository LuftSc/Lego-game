using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public static GameObject target;

    private static bool goMove = true;

    //public static List<Vector3> positionList = new List<Vector3>();
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                var parent = hit.transform.parent.gameObject;
                parent = parent.name == "Triangle" ? parent.transform.parent.gameObject : parent;
                if (parent.CompareTag("InterfaceElement"))
                {
                    Move(parent);
                }
            }
        }
    }

    public void Move(GameObject moveArrows)
    {
        var objPos = target.transform.position;
        if (goMove)
        {
            var allArrows = moveArrows.transform.parent.transform.parent;
            var arrPos = allArrows.transform.position;
            var detailIsFar = true;
            //var newPos = new Vector3();
            Action<Vector3> moveObj = (v) =>
            {
                /* var newPos = ClickToMoveButton.GetCenterPosition(target.transform) + v;
                foreach (var wallPosition in ClickToMoveButton.positionList)
                {
                    var direct = v.x == 0 ? 'z' : 'x';
                    Debug.Log(CheckTwoVectors3OnEquals(direct, wallPosition, newPos));

                    if (CheckTwoVectors3OnEquals(direct, wallPosition, newPos))
                    {
                        detailIsFar = false;
                        break;
                    }
                }

                if (detailIsFar)
                { */
                    target.transform.position = objPos + v;
                    allArrows.transform.position = arrPos + v;
                //} 
            };
            switch (moveArrows.name)
            {
                case "Red_Arrow_X":
                    moveObj(new Vector3(3f, 0, 0));
                    /*
                    newPos = objPos + new Vector3(3f, 0, 0);
                    
                    foreach (var wallPosition in positionList)
                        if (CheckTwoVectors3OnEquals(wallPosition, newPos)){ detailIsFar = false; break;}
                    
                    if (detailIsFar)
                    {
                        target.transform.position = objPos + new Vector3(3f,0,0);
                        allArrows.transform.position = arrPos + new Vector3(3f, 0, 0);
                    } */
                    break;
                case "Red_Arrow_XM":
                    moveObj(new Vector3(-3f, 0, 0));
                    /*
                    newPos = objPos + new Vector3(-3f,0,0);
                    target.transform.position = objPos + new Vector3(-3f,0,0);
                    allArrows.transform.position = arrPos + new Vector3(-3f, 0, 0); */

                    break;
                case "Blue_Arrow_Z":
                    moveObj(new Vector3(0, 0, 3f));
                    /*
                    newPos = objPos + new Vector3(0,0,3f);
                    target.transform.position = objPos + new Vector3(0,0,3f);
                    allArrows.transform.position = arrPos + new Vector3(0, 0, 3f); */
                    break;
                case "Blue_Arrow_ZM":
                    moveObj(new Vector3(0, 0, -3f));
                    /*
                    newPos = objPos + new Vector3(0,0,-3f);
                    target.transform.position = objPos + new Vector3(0,0,-3f);
                    allArrows.transform.position = arrPos + new Vector3(0, 0, -3f); */
                    break;

            }
        }

        goMove = false;
        StartCoroutine(waiter());
    }

    public static bool CheckTwoVectors3OnEquals(Char direct, Vector3 vector1, Vector3 vector2)
    {
        var result = false;
        if (direct == 'x')
        {
            Debug.Log($"v1x: {MathF.Abs(vector1.x)} v2x: {MathF.Abs(vector2.x)}");
            result = MathF.Abs(MathF.Abs(vector1.x) - MathF.Abs(vector2.x)) < 1 &&
                     MathF.Abs(MathF.Abs(vector1.z) - MathF.Abs(vector2.z)) < 3.5f;

        }
        else
        {
            result = MathF.Abs(MathF.Abs(vector1.x) - MathF.Abs(vector2.x)) < 3.5f &&
                     MathF.Abs(MathF.Abs(vector1.z) - MathF.Abs(vector2.z)) < 1;
        }

        return result;
        //return direct == 'x'
        //? MathF.Abs(MathF.Abs(vector1.x) - MathF.Abs(vector2.x)) < 1
        //: MathF.Abs(MathF.Abs(vector1.z) - MathF.Abs(vector2.z)) < 1;

        //var checkX = MathF.Abs(MathF.Abs(vector1.x) - MathF.Abs(vector2.x)) > 1;
        //var checkY = MathF.Abs(MathF.Abs(vector1.y) - MathF.Abs(vector2.y)) > 1;
        //var checkZ = MathF.Abs(MathF.Abs(vector1.z) - MathF.Abs(vector2.z)) > 1;

        //return checkX || checkY || checkZ;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
        goMove = true;
    }
}