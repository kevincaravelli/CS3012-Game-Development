using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float velocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        // Current position of player
        var position = transform.position;

        // Update the x component when moving on the horizontal axis
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * velocity;

        // Update the y component when jumping (this will have them fly for now)
        position.y += Input.GetAxis("Vertical") * Time.deltaTime * velocity;

        transform.position = position;
    }
}
