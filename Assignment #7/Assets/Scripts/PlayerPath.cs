using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPath : MonoBehaviour
{
    private List<string> rooms = new List<string>();

    private void Awake()
    {
        // Count the # of objects of type PlayerPath
        int playerPathCount = FindObjectsOfType<PlayerPath>().Length;

        if (playerPathCount > 1)
        {
            // destroy myself
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // make this object persist
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public void addRoom(string room)
    {
        // Adds the current room to the list of rooms visited
        rooms.Add(room);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
