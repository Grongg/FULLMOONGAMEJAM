using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerPosition;
    public float boundaryUp;
    public float boundaryDown;
    public float boundaryLeft;
    public float boundaryRight;

    void Start()
    {
        
    }

    void Update()
    {
        float xPos = playerPosition.position.x;
        float yPos = playerPosition.position.y;

        if (xPos < boundaryLeft)
            xPos = boundaryLeft;
        if (xPos > boundaryRight)
            xPos = boundaryRight;
        if (yPos < boundaryDown)
            yPos = boundaryDown;
        if (yPos > boundaryUp)
            yPos = boundaryUp;
        transform.position = new Vector3(xPos, yPos, -10);
    }
}
