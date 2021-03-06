using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaftyPlatform : MonoBehaviour
{
    [SerializeField] float velocity = 10.0f;
    [SerializeField] float constraintMax, constraintMin;
    [SerializeField] GameObject player;
    private float distance;
    private bool closer = false;

    // Start is called before the first frame update
    void Start()
    {
        checkDistance();
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();
        movePlatform();

    }

    private void movePlatform()
    {
        var position = transform.position;

        if (player.transform.position.x < (transform.position.x - 2.5f) && player.GetComponent<SpriteRenderer>().flipX)
        {
            // Player is left of platform && player is facing left
            position.y += Time.deltaTime * -velocity;
        } else if (player.transform.position.x > (transform.position.x + 2.5f) && !player.GetComponent<SpriteRenderer>().flipX)    
        {
            // Player is right of platform && player is facing right
            position.y += Time.deltaTime * -velocity;
        } else
        {
            position.y += Time.deltaTime * velocity;
        }

        /*
        if (closer) // Platform goes up if closer is true
        {
            position.y += Time.deltaTime * velocity;
        } else
        {
            position.y += Time.deltaTime * -velocity;
        }
        */
        // Constrain the saftey platform inbetween -1.5 and -7.5
        if (position.y >= constraintMax) position.y = constraintMax;
        if (position.y <= constraintMin) position.y = constraintMin;

        transform.position = position;
    }

    private void checkDistance()
    {
        /*
        var playerPos = new Vector2(player.transform.position.x, 0.0f);
        var platformPos = new Vector2(transform.position.x, 0.0f);
        var checkDist = Vector2.Distance(platformPos, playerPos);
        */
        var checkDist = Vector2.Distance(transform.position, player.transform.position);


        // Check if the distance is less then it was (player getting closer)
        if ( checkDist < distance || checkDist <= 8)
        {
            closer = true;
        } else
        {
            closer = false;
        }

        distance = checkDist;
    }

}
