using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Bumped into a wall");
        if (other.gameObject.tag == "Player")
            GetComponent<MeshRenderer>().material.color = Color.red;
    }

}
