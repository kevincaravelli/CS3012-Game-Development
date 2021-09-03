using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] GameObject mySquare;
    [SerializeField] float velocity;    // Units per second
    [SerializeField] GameObject bob;
    [SerializeField] float bobSpeed;

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

        // Detect a key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // moce the square up by one unity unit
            currentPosition.y += 1.0f;
        }

        // detect a primary button pressed on the mouse
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition); // Absolute pixel position, not unity units
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
        // Debug.Log(currentPosition);

        // Debug.Log(Time.deltaTime); // Time between frames
        // Frames per second = 1 second / Time.deltaTime

        currentPosition.x += velocity * Time.deltaTime;
        mySquare.transform.position = currentPosition;

        // bob's movement
        var targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // vector3
        var bobPosition = bob.transform.position; // vector3

        var newPosition = Vector2.MoveTowards(new Vector2(bobPosition.x, bobPosition.y), 
            new Vector2(targetPosition.x, targetPosition.y), bobSpeed * Time.deltaTime);

        bobPosition.x = newPosition.x;
        bobPosition.y = newPosition.y;

        // now move bob to the new location
        bob.transform.position = bobPosition;
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
