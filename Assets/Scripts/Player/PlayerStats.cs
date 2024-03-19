using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Variables
    [Header("Player Statistics")]
    public int playerHealth = 100;
    public bool isPlayerDead = false;
    public bool playerWon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
    }

    // Functions
    private void CheckPlayerStatus()
    {
        if (playerHealth <= 0)
        {
            isPlayerDead = true;
        }
    }

    // Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Lava")
        {
            isPlayerDead = true;
            //gameManager.ActionHappenedSound(death);
            Debug.Log("Player was hurt by an enemy or melted to death...");
            gameObject.SetActive(false);
            //Invoke("LoadLose", death.length);
        }

        if (other.gameObject.tag == "Key")
        {
            //score++;
            Debug.Log("Player collected a coin!");
        }
    }

    // Triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chalice")
        {
            playerWon = true;
            //gameManager.ActionHappenedSound(won);
            Debug.Log("Player finished the level!");
            gameObject.SetActive(false);
            //Invoke("LoadWin", won.length);
        }
    }
}
