using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatistics", menuName = "Scriptable Objects/Game Statistics")]
public class GameStatistics : ScriptableObject
{
    // Variables
    public int playerHealth;
    public float timeLeft;
    public int keysCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Constructor Empty
    public GameStatistics()
    {

    }

    // Functions


    // Set and Get Functions
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
