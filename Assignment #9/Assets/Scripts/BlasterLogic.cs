using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterLogic : MonoBehaviour
{
    [SerializeField] float velocity = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7) * velocity;

        if (transform.position.y > 12) Destroy(gameObject);
    }
}
