using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithNumber : MonoBehaviour
{
    public int NumberOfScene;
    
    public void OnClick()
    {
        SceneManager.LoadScene(NumberOfScene);
    }
}
