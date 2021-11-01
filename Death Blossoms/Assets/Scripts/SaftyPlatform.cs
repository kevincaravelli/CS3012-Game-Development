using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaftyPlatform : MonoBehaviour
{
    [SerializeField] float velocity = 10.0f;
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

        if (closer) // Platform goes up if closer is true
        {
            position.y += Time.deltaTime * velocity;
        } else
        {
            position.y += Time.deltaTime * -velocity;
        }

        // Constrain the saftey platform inbetween -1.5 and -7.5
        if (position.y >= -1.5) position.y = -1.5f;
        if (position.y <= -7.5) position.y = -7.5f;

        transform.position = position;
    }

    private void checkDistance()
    {
        var playerPos = player.transform.position;
        var position = transform.position;
        var checkDist = Vector2.Distance(position, playerPos);

        // Check if the distance is less then it was (player getting closer)
        if ( checkDist < distance || checkDist < 8.0f)
        {
            closer = true;
        } else
        {
            closer = false;
        }

        distance = checkDist;
    }

}
