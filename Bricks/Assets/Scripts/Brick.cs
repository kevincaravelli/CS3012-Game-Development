using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // red: unbreakable
    // blue: 1 hit
    // green: 4 hits
    // yellow" 3 hits
    [SerializeField] int HP; // unbreakable for now is HP -1
    [SerializeField] Sprite[] sprites;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure it is rendered using the full HP sprite
        // sprites.length - 1
        chooseCurrentSprite();

        // link the audio soruce componet and cache it for use later
        audio = GetComponent<AudioSource>();

        Debug.Log(tag);
    }

    private void chooseCurrentSprite()
    {
        if (HP > 0)
            GetComponent<SpriteRenderer>().sprite = sprites[HP - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // method called upon collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Brick Hit! " + name);

        // play the audio clip every collision

        audio.Play();
        // GetComponent<AudioSource>().Play();
        
        if (tag.Equals("Unbreakable"))
        {
            // Unbreakable brick
            // do nothing
        } else
        {
            // Decrease the HP
            HP--;
            Debug.Log(HP);
            chooseCurrentSprite();
            if (HP == 0)
            {
                transform.position = new Vector3(-100.0f, -100.0f, 0.0f);
                Destroy(gameObject, 2.0f); // destroys the game object (not this)
            }
        }
    }


}
