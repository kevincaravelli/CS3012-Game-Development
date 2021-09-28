using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // If there is no direction to load it will be a negative value
    [SerializeField] int up, down, left, right;
    private PlayerPath paths;

    // Start is called before the first frame update
    void Start()
    {
        paths.addRoom(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        // Load the correspomding schen depending on which key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow) && up >= 0) loadScene(up);
        if (Input.GetKeyDown(KeyCode.DownArrow) && down >= 0) loadScene(down);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && left >= 0) loadScene(left);
        if (Input.GetKeyDown(KeyCode.RightArrow) && right >= 0) loadScene(right);
    }

    void loadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
