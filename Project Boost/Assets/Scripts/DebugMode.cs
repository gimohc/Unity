using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool collisionEnabled;
    void Start()
    {
        collisionEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        debugMenu();
    }
    private void debugMenu()
    {
        //CollisionHandler collisionHandler = new CollisionHandler();
        if (Input.GetKeyDown(KeyCode.L))
            CollisionHandler.loadNext();
        else if (Input.GetKeyDown(KeyCode.C))
            toggleCollisions();

    }

    public static bool toggleCollisions()
    {
        collisionEnabled = !collisionEnabled;
        return collisionEnabled;

    }
}
