using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip fail;
    private Movement movementScript;
    private AudioSource audioSource;


    private void Start()
    {
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            /*case "Fuel":
                Debug.Log("Took fuel.");
                break;*/
            case "Start":
                Debug.Log("Back to the start.");
                break;
            case "Finish":
                finishSequence();
                Debug.Log("Finished. ");
                break;
            default:
                Debug.Log("Hit the ground. ");
                crashSequence();
                break;

        }
    }
    private void reloadScene()
    {
        // TODO ADD SOUNDEFFECTS
        String sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        //SceneManager.GetSceneByBuildIndex();
    }

    private void loadNext()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings == sceneNumber + 1)
            sceneNumber = -1;
        SceneManager.LoadScene(sceneNumber + 1);
    }
    private void crashSequence()
    {
        movementScript.enabled = false;
        audioSource.PlayOneShot(fail);
        Invoke("reloadScene", 2f);
    }
    private void finishSequence()
    {
        movementScript.enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("loadNext", 2f);

    }
}
