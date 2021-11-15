using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField] float velocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 xMovement = Vector3.right * velocity * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 yMovement = Vector3.up * velocity * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 movement = xMovement + yMovement;
        transform.position += movement;

        movement = Vector3.Normalize(movement);
        float dX = movement.x;
        float dY = movement.y;

        if (dX == 0.0f && dY == 0.0f)
        {
            // idling
            myAnimator.SetBool("walking", false);
        } else
        {
            // walking
            myAnimator.SetBool("walking", true);
            myAnimator.SetFloat("moveX", dX);
            myAnimator.SetFloat("moveY", dY);
        }

    }
}
