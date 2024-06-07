using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip fail;

    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem failParticles;

    private Movement movementScript;
    private AudioSource audioSource;

    private bool isTransitioning = false;

    private void Start()
    {
        movementScript = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || !DebugMode.collisionEnabled)
            return;

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
        //isTransitioning = false;
    }
    private void reloadScene()
    {
        String sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        //SceneManager.GetSceneByBuildIndex();
    }

    public static void loadNext()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings == sceneNumber + 1)
            sceneNumber = -1;
        SceneManager.LoadScene(sceneNumber + 1);
    }
    private void actuallyLoadNext() {
        loadNext();
    }
    private void crashSequence()
    {
        isTransitioning = true;
        movementScript.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(fail);
        failParticles.Play();
        Invoke("reloadScene", 2f);
    }
    private void finishSequence()
    {
        isTransitioning = true;
        movementScript.enabled = false;
        audioSource.Stop();
        successParticles.Play();
        audioSource.PlayOneShot(success);
        Invoke("actuallyLoadNext", 2f);

    }

    // add new method with only the static method and make it non static. call invoke inside the non static

}
