using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    [Header("Music InMenu Audio Source")]
    public AudioSource musicInmenu;

    // Start is called before the first frame update
    void Start()
    {
        musicInmenu = GameObject.Find("Sound Manager").transform.Find("Music in-menu").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
}
