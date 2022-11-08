using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_1x2 : MonoBehaviour
{
    public GameObject cubePrefab_1x2;
    public void onClick() 
    {
        ClickControl.cubeChoosen = true;
        ClickControl.cubePrefab = cubePrefab_1x2;
    }
}
