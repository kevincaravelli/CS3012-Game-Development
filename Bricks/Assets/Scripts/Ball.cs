using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    bool sticky = true;
    [SerializeField] float launchVelocity = 20.0f;
    [SerializeField] GameObject paddle;

    // Start is called before the first frame update
    void Start()
    {
        followPaddle();
    }

    // Update is called once per frame
    void Update()
    {
        if (sticky) followPaddle();
        if (sticky && Input.GetButtonDown("Fire1"))
        {
            launch();
        }
    }

    void launch()
    {
        sticky = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 1.0f) * launchVelocity;
    }

    // place the ball object on top of the paddle
    void followPaddle()
    {
        // get the position of the paddle object
        var paddlePos = paddle.transform.position;
        var ballPos = paddlePos + new Vector3(0.0f, 1.0f, 0.0f);

        transform.position = ballPos;
    }
}
