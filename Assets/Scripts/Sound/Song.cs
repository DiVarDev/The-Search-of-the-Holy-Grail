using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    // Variables
    private AudioClip songClip;
    public string songName;
    public float length;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Constructor Empty
    public Song()
    {

    }

    // Constructor
    public Song(AudioClip song, string name, float length)
    {
        this.songClip = song;
        this.songName = name;
        this.length = length;
    }

    // Functions
}
