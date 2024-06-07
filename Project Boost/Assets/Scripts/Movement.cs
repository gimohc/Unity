using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustingAdjustment;
    [SerializeField] private float rotationAdjustment;
    [SerializeField] private AudioClip thrustSFX;
    [SerializeField] private ParticleSystem leftRotation;
    [SerializeField] private ParticleSystem rightRotation;
    [SerializeField] private ParticleSystem leftEngine;
    [SerializeField] private ParticleSystem rightEngine;


    private Rigidbody rigidBody;
    private AudioSource audioSource;
    //comment 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrustingAdjustment = 1000f;
        rotationAdjustment = 100f;// * Time.deltaTime;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        handleThrusting();
        handleRotation();

    }

    private void handleThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
            startMainEngine();
    
        else
            stopMainEngine();
        

    }
    private void startMainEngine() {
        if (!audioSource.isPlaying)
                audioSource.PlayOneShot(thrustSFX);
            rigidBody.AddRelativeForce(thrustingAdjustment * Time.deltaTime * Vector3.up);
        if(!leftEngine.isPlaying) {
            leftEngine.Play();
            rightEngine.Play(); // no need to check for both cause they're both starting and stopping together
        }
    }
    private void stopMainEngine() {
        audioSource.Stop();
        leftEngine.Stop();
        rightEngine.Stop();
    }
    private void handleRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!leftRotation.isPlaying)
                leftRotation.Play();
            processRotation(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (leftRotation.isPlaying)
                leftRotation.Stop();
            if (!rightRotation.isPlaying)
                rightRotation.Play();
            processRotation(1);
            // transform.Rotate(Vector3.forward);
        }
        else
        {
            leftRotation.Stop();
            rightRotation.Stop();
        }
    }
    private void processRotation(int x)
    {
        rigidBody.freezeRotation = true; // giving higher priority to manual rotation
        transform.Rotate(x * rotationAdjustment * Time.deltaTime, 0, 0);
        rigidBody.freezeRotation = false; // giving physics system back priority rotation
    }

}
