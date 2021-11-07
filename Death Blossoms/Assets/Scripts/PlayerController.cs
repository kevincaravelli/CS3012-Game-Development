using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float velocity = 5.0f;
    [SerializeField] float jumpForce = 10.0f;
    private Vector2 jump = new Vector2(0.0f, 2.0f);
    private bool isGrounded;

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

        // Have the player jump only if they are on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }



        transform.position = position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
