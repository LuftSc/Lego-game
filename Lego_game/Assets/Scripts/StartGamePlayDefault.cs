using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGamePlayDefault : MonoBehaviour
{
    public static void OnClick()
    {
        SceneManager.LoadScene(2);
    }
}