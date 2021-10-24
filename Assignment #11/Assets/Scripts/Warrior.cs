using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] bool player;
    [SerializeField] float velocity = 5.0f;
    [SerializeField] GameObject fireBallPrefab;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            movePlayer();

            if (Input.GetButtonDown("Fire1")) fireBall();
        }
    }

    private void movePlayer()
    {
        Vector3 yMovement = Vector3.up * velocity * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 movement = yMovement;

        transform.position += movement;

        movement = Vector3.Normalize(movement);
        float dY = movement.y;

        if (dY == 0.0f)
        {
            // idling
            myAnimator.SetBool("walking", false);
        }
        else
        {
            // walking
            myAnimator.SetBool("walking", true);
            myAnimator.SetFloat("moveY", dY);
        }
    }

    private void fireBall()
    {
        myAnimator.SetBool("attack", true);
        StartCoroutine(attack());
        Instantiate((fireBallPrefab),
            new Vector3(transform.position.x + 1.0f, transform.position.y - 0.5f, 0), Quaternion.identity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myAnimator.SetBool("alive", true);
        Debug.Log("I was Hit: " + myAnimator.GetBool("alive"));

        StartCoroutine(destroyEnemy());
        Destroy(collision.gameObject);
    }

    IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(1);
        myAnimator.SetBool("attack", false);
    }
}
