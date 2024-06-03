using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float speedConstant = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        printInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
    void printInstructions()
    {

        Debug.Log("Game start");
        Debug.Log("Move with WASD don't hit objects");

    }
    void movePlayer()
    {
        float x = speedConstant * Input.GetAxis("Horizontal") * Time.deltaTime;
        float y = speedConstant * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(x, y, 0);
    }

}
