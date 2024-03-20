using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Variables
    [Header("Enemy Statistics")]
    public int health = 25;
    public int attackDamage = 3;
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
    public AudioSource soundGame;

    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        attackDamage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void LosesHealth(int value)
    {
        
    }

    // Collistions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            Debug.Log("Enemy touching ground or a platform!");
        }

        if (other.gameObject.tag == "Sword")
        {
            if (transform.GetComponent<CapsuleCollider2D>().IsTouching(other.collider))
            {
                if (health > 0)
                {
                    health -= other.gameObject.GetComponent<PlayerStats>().attackDamage;
                    soundGame.PlayOneShot(hurt);
                }
                else if (health <= 0)
                {
                    isDead = true;
                    soundGame.PlayOneShot(death);
                    Debug.Log("Enemy was hurt by a player to death...");
                    gameObject.SetActive(false);
                    //Invoke("LoadLose", death.length);
                }
            }
        }
    }
}
