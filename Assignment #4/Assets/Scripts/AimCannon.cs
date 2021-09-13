using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCannon : MonoBehaviour
{
    bool loaded = true;
    [SerializeField] float velocity = 30.0f;
    [SerializeField] float launchVelocity = 40.0f;
    [SerializeField] GameObject cannonBall;

    // Start is called before the first frame update
    void Start()
    {
        load();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cannon
        rotateCannon();

        // load cannon ball into cannon
        if (loaded) load();

        // Fire cannon ball
        if (loaded && Input.GetButtonDown("Fire1"))
        {
            launch();
        }

        // Reset frame if ball goes under -10.5
        if (cannonBall.transform.position.y < -10.5) loaded = true;
    }

    void launch()
    {
        loaded = false;

        var launchAngle = transform.eulerAngles;
        Debug.Log(launchAngle);

        var launchX = -1 * Mathf.Sin(launchAngle.z * Mathf.Deg2Rad);
        var launchY = Mathf.Cos(launchAngle.z * Mathf.Deg2Rad);
        cannonBall.GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY) * launchVelocity;
    }

    // place the cannon ball object  in the middle of the cannon
    void load()
    {
        cannonBall.transform.position = transform.position;
    }

    void rotateCannon()
    {
        var rotation = transform.rotation;

        rotation.z += Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
        if (rotation.z > 0.5f)
        {
            rotation.z = 0.49f;
        }
        if (rotation.z < -0.5f)
        {
            rotation.z = -0.49f;
        }

        // Debug.Log(rotation.z);

        transform.rotation = rotation;
    }
}
