using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private float[] velocities = { 5.0f, 10.0f, 20.0f };
    [SerializeField] GameObject starPrefab;
    private int difficulty = 1;

    public float getVelocity()
    {
        return velocities[difficulty];
    }

    public void changeDifficlty()
    {
        difficulty = (difficulty + 1) % velocities.Length;
    }
    private void Awake()
    {
        // Count the # of objects of type GameSettings
        int gameSetingsCount = FindObjectsOfType<GameSettings>().Length;

        if (gameSetingsCount > 1)
        {
            // destroy myself
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            // make this object persist
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate((starPrefab), new Vector3(0, 0, 10), Quaternion.identity);
        }
    }
}
