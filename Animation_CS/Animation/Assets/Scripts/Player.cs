using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocity;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * velocity * Time.deltaTime
            * Input.GetAxis("Horizontal");
        bool movingRight = movement.x >= 0.0;
//        myAnimator.SetBool("movingRight", movingRight);
        myAnimator.SetFloat("velocity", movement.x);
        transform.position += movement;
    }
}
