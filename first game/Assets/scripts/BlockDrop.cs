using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int time = 4;
    MeshRenderer renderer;
    Rigidbody body;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        renderer.enabled = false;
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time)
        {
            renderer.enabled = true;
            body.useGravity = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            renderer.material.color = Color.red;
    }
}
