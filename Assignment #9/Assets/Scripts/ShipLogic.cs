using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    [SerializeField] float velocity = 10.0f;
    [SerializeField] Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerShip();
    }

    void movePlayerShip()
    {
        // Current paddle position
        var position = transform.position;

        // update the x componet of the position by the inpyut on the horizion axis
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * velocity;

        // Changes the sprite depending on which way its going
        if (Input.GetAxis("Horizontal") == 0.0f) GetComponent<SpriteRenderer>().sprite = sprites[0];
        if (Input.GetAxis("Horizontal") < 0.0f) GetComponent<SpriteRenderer>().sprite = sprites[1];
        if (Input.GetAxis("Horizontal") > 0.0f) GetComponent<SpriteRenderer>().sprite = sprites[2];

        // Restrict spaceship from going to far to the right and left
        if (transform.position.x < -5.0f) position.x = -5.0f;
        if (transform.position.x > 5.0f) position.x = 5.0f;

        transform.position = position;
    }
}
