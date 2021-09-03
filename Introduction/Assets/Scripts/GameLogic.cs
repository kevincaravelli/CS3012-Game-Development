using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] GameObject mySquare;
    [SerializeField] float velocity;    // Units per second

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start. We should see this only once");
        Debug.Log(mySquare);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("I should keep seeing this!");
        var currentPosition = mySquare.transform.position;
        // Debug.Log(currentPosition);

        // Debug.Log(Time.deltaTime); // Time between frames
        // Frames per second = 1 second / Time.deltaTime

        currentPosition.x += velocity * Time.deltaTime;
        mySquare.transform.position = currentPosition;
    }

    public void flipDirection()
    {
        velocity = -velocity;
    }

    public void moveVertically(int factor)
    {
        var currentPosition = mySquare.transform.position;
        currentPosition.y += factor * velocity * Time.deltaTime;
        mySquare.transform.position = currentPosition;
    }
}
