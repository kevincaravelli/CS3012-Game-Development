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
        if (position.y > 10.0f)
        {
            Destroy(gameObject);
            FindObjectOfType<SpawnEnemies>().spawnEnemy();
        }

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Blaster"))
        {
            // Destroy the blaster object
            Destroy(collision.gameObject);

            // When this gameObject's HP reaches 0 DESTROY IT!!!
            HP--;
            if (HP == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<SpawnEnemies>().spawnEnemy();
            }
        }
    }

}
