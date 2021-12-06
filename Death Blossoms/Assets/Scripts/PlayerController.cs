using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float velocity = 5.0f;
    [SerializeField] float jumpForce = 3.5f;
    private Vector2 input;
    private Vector2 jump = new Vector2(0.0f, 2.0f);
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    public bool isJumping;
    public float jumpSpeed = 8f;
    public float jumpDurationThreshold = 0.25f;
    private float jumpDuration;
    private float rayCastLengthCheck = 0.005f;
    private float width;
    private float height;
    private bool frozen;
 


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            movePlayer();
        } else
        {
            myAnimator.SetBool("running", false);
        }
        

    }

    private void movePlayer()
    {
        input.y = Input.GetAxis("Jump");
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
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsOnGround())
        {
            GetComponent<Rigidbody2D>().AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool PlayerIsOnGround()
    {
        // Establish raycasts
        bool groundCheck1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), -Vector2.up, rayCastLengthCheck);
        bool groundCheck2 = Physics2D.Raycast(new Vector2(transform.position.x + (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLengthCheck);
        bool groundCheck3 = Physics2D.Raycast(new Vector2(transform.position.x - (width - 0.2f), transform.position.y - height), -Vector2.up, rayCastLengthCheck);

        // Check each raycast and if any of them are grounded they are on the ground
        if (groundCheck1 || groundCheck2 || groundCheck3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void freezePlayer()
    {
        frozen = true;
    }

    public void freePlayer()
    {
        frozen = false;
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        // if (collision.gameObject.name != "Walls") isGrounded = true;
        myAnimator.SetBool("jumping", false);
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        // isGrounded = false;
        myAnimator.SetBool("jumping", true);
    }
    
}
