using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Variables
    [Header("Enemy Statistics")]
    public int maxHealth = 25;
    public int health;
    public int attackDamage = 5;
    public bool hasJump = false;
    public bool isHurt = false;
    public bool isDead = false;
    public bool isWalking = false;
    public bool isIdle = false;
    [Header("Enemy Sounds")]
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip walk;
    public AudioClip idle;
    public AudioClip message;
    [Header("Enemy Sounds")]
    public AudioSource audioSource;
    public AudioSource soundGame;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        soundGame = GameObject.Find("Sound Manager").transform.Find("Sound Game").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyStatus();
    }

    // Functions
    public void CheckEnemyStatus()
    {
        if (health <= 0)
        {
            isDead = true;
            soundGame.PlayOneShot(death);
            Debug.Log("Enemy was hurt by a player to death...");
            gameObject.SetActive(false);
            //Invoke("LoadLose", death.length);
        }
    }

    // Collistions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            Debug.Log("Enemy touching ground or a platform!");
        }

        if (other.gameObject.tag == "Player")
        {
            if (transform.GetComponent<CapsuleCollider2D>().IsTouching(other.gameObject.transform.Find("Sword").GetComponent<PolygonCollider2D>()))
            {
                if (health > 0)
                {
                    health -= other.gameObject.GetComponent<PlayerStats>().attackDamage;
                    audioSource.PlayOneShot(hurt);
                    Debug.Log("Enemy is taking damage...");
                }
            }
        }
    }
}
