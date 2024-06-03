using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private SceneManager manager;
    void Start()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Took fuel.");
                break;
            case "Start":
                Debug.Log("Back to the start.");
                break;
            case "Finish":
                Debug.Log("Finished. ");
                break;
            default:
                Debug.Log("Hit the ground. ");
                reloadScene();
                break;

        }
    }
    private void reloadScene()
    {
        String sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        //SceneManager.GetSceneByBuildIndex();
    }
}
