using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] AudioClip[] music;
    private int currentMusic;
    private AudioSource myAudio;

    private void Awake()
    {
        // Count the # of objects of type GameSettings
        int gameSetingsCount = FindObjectsOfType<GameSettings>().Length;

        if (gameSetingsCount > 1)
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

    // Start is called before the first frame update
    void Start()
    {
        currentMusic = 0;
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Read the player prefs volume value
        float userVolume;
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            userVolume = PlayerPrefs.GetFloat("VOLUME");
        }
        else
        {
            userVolume = 0.5f;
        }

        myAudio.volume = userVolume;

        if (!myAudio.isPlaying)
        {
            currentMusic = (currentMusic + 1) % music.Length;
            myAudio.clip = music[currentMusic];
            myAudio.Play();
        }
    }
}
