using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void loadMainMenu()
    {
        StartCoroutine(LoadLevel("Main Menu"));
    }

    public void loadOptionsMenu()
    {
        StartCoroutine(LoadLevel("Options Menu"));
    }

    public void loadScene(int sceneID)
    {
        StartCoroutine(LoadLevel(sceneID));
    }

    public void loadScene(string sceneID)
    {
        StartCoroutine(LoadLevel(sceneID));
    }

    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        // Play Animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
