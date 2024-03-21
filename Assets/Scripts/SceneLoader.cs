using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Functions
    public void LoadSceneAsyncByIndex(int scene) // Function to load Scene by Index
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }

    public void LoadSceneAsyncByName(string scene) // Function to load Scene by Name
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}
