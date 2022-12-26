using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHideHairs : MonoBehaviour
{
    public GameObject hair;

    public void OnClick()
    {
        if (hair.activeSelf) hair.SetActive(false);
        else hair.SetActive(true);
    }
}
