using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int amountOfBumps = -1;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            Debug.Log("Total amount of bumps: " + (++amountOfBumps));
            other.gameObject.tag = "Hit";
        }
    }
}