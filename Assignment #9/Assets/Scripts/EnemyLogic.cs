using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] int HP; // weak have 3 HP, stronger have 5
    [SerializeField] float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();

    }

    private void moveEnemy()
    {
        // Current paddle position
        var position = transform.position;

        // update the x componet of the position by the inpyut on the horizion axis
        position.x += Time.deltaTime * velocity;

        if (position.x > 8.0f) position.x = -8;

        transform.position = position;
    }

}
