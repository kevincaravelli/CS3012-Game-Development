using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Load the stored preference value for the volume
        FindObjectOfType<Slider>().value = PlayerPrefs.GetFloat("VOLUME");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(FindObjectOfType<Slider>().value);
        // Use PlayerPrefs to store this information
        PlayerPrefs.SetFloat("VOLUME", FindObjectOfType<Slider>().value);
    }

    public void setDefaultVolume()
    {
        // default volume is 0.5
        FindObjectOfType<Slider>().value = 0.5f;
    }
}
