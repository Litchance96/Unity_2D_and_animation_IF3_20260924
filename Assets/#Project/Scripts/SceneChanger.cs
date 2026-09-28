using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName = "";


    private void Awake()
    {

        sceneName = sceneName.Trim();
        if (sceneName == "")
        {
            Debug.LogError ("Scene name cannot be empty.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
