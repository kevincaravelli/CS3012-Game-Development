using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    [SerializeField] float velocity;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        velocity = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        transform.position += movement;
        if (movement.x > 0.0)
        {
            myRenderer.flipX = false;
        }
        if (movement.x < 0.0)
        {
            myRenderer.flipX = true;
        }
    }
}
