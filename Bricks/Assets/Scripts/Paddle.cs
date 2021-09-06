using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float velocity; 


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        /*
         * if (Input.GetkeyDown(KeyCode.Left);
         *      // do something
         */

        // Current paddle position
        var position = transform.position;

        // update the x componet of the position by the inpyut on the horizion axis
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * velocity;

        transform.position = position;
    }
}

