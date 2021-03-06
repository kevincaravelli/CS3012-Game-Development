using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Breakable Bricks left: " + GameObject.FindGameObjectsWithTag("Breakable").Length);
        // Debug.Log("Unbreakable bricks   : " + GameObject.FindGameObjectsWithTag("Unbreakable").Length);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Not OnCollisionEnter2D
    {
        // Debug.Log("GAME OVER!");

        // find the scene loader game object
        // and call the loadScene method
        // FindObjectOfType<SceneLoader>().loadScene(0);

        // reset the ball back to the paddle
        // collision.gameObject.GetComponent<Ball>().Reset();

        // destroy the ball instead
        Destroy(collision.gameObject);

        // Create a brand new ball
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
