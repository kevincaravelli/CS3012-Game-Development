using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8.0f, 8.0f), 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
