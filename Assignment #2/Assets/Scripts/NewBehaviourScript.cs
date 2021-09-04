using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject mySquare;
    float RotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the square counter clockwise
        mySquare.transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);
    }

    public void updateRotationVelocity(float speed)
    {
        RotationSpeed += speed;
    }
}
