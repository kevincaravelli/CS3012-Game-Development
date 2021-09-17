using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void changeDifficulty()
    {
        FindObjectOfType<GameSettings>().changeDifficlty();
    }
}
