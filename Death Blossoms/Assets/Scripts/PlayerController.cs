using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float velocity = 5.0f;
    [SerializeField] float jumpForce = 3.5f;
    private Vector2 jump = new Vector2(0.0f, 2.0f);
    private bool isGrounded;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        // Current position of player
        // Update the x component when moving on the horizontal axis
        Vector3 position = Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * velocity;

        // The player can crouch
        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnimator.SetBool("crouch", true);
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            myAnimator.SetBool("crouch", false);
        }

        if (!myAnimator.GetBool("crouch"))
        {
            // player cant move if they are crouching
            transform.position += position;
        }

        position = Vector3.Normalize(position);
        float dX = position.x;

        if (dX == 0.0f)
        {
            // idling
            myAnimator.SetBool("running", false);
        }
        else
        {
            // walking
            myAnimator.SetBool("running", true);
            // myAnimator.SetFloat("moveX", dX);
        }

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
        myAnimator.SetBool("jumping", false);
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        myAnimator.SetBool("jumping", true);
    }
}
