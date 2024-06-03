using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float thrustingAdjustment;
    [SerializeField] private float rotationAdjustment;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrustingAdjustment = 1000f;
        rotationAdjustment = 10f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        //Input.getk
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(thrustingAdjustment * Time.deltaTime * Vector3.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            processRotation(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            processRotation(1);
            // transform.Rotate(Vector3.forward);
        }
    }
    private void processRotation (int x) {
        rigidBody.freezeRotation = true; // giving higher priority to manual rotation
        transform.Rotate(x * rotationAdjustment, 0, 0);
        rigidBody.freezeRotation = false; // giving physics system back priority rotation
    }

}
