using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float velocity = 5.0f;
    [SerializeField] float jumpForce = 10.0f;
    private Vector2 jump = new Vector2(0.0f, 2.0f);
    private bool isGrounded;
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        // Current position of player
        // var position = transform.position;

        // Update the x component when moving on the horizontal axis
        Vector3 position = Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * velocity;

        transform.position += position;

        if (position.x > 0.0)
        {
            myRenderer.flipX = false;
        }
        if (position.x < 0.0)
        {
            myRenderer.flipX = true;
        }

        // Have the player jump only if they are on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }*/
}
