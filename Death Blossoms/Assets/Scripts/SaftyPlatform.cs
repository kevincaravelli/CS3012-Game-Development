using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaftyPlatform : MonoBehaviour
{
    [SerializeField] float velocity = 10.0f;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void movePlatform()
    {
        // Current position of platform
        var position = transform.position;
        var playerPos = player.transform.position;

        // We only want the platform as the player gets closer
        // It has to be at the ground level by the time they arrive
        // Update the y component
        position.y += playerPos.x * Time.deltaTime * velocity;

        transform.position = position;
    }
}
