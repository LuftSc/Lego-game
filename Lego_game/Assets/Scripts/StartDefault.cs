using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDefault : MonoBehaviour
{
    // Start is called before the first frame update
    public static void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}