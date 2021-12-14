using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{

    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        director.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        director.Play();
    }
}
