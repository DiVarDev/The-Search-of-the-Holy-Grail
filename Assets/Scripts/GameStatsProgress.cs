using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsProgress : MonoBehaviour
{
    // Variables
    public bool isObjectDestroyedOnload = false;
    [Header("Stats Values")]
    public int playerHealth;
    public float timeLeft;
    public int keysCollected;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetPlayerHealth(int value)
    {
        playerHealth = value;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetTimeLeft(float value)
    {
        timeLeft = value;
    }

    public int GetKeysCollected()
    {
        return keysCollected;
    }

    public void SetKeysCollected(int value)
    {
        keysCollected = value;
    }
}
