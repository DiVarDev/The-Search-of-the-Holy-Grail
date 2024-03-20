using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [Header("Player RigidBody 2D and Axis Position")]
    public Rigidbody2D rigidBody;
    private Vector3 axisSpeeds;
    [Header("Player Variables")]
    public float jumpHeight = 3.0f;
    public float speed = 5.0f;
    public bool isGrounded;
    public bool isAttacking = false;
    public bool isLookingLeft = false;
    public bool isLookingRight = false;
    public bool isWalking = false;
    public bool isIdle = false;
    [Header("Player Stats")]
    public PlayerStats playerStats;
    [Header("World Variables")]
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = playerStats.animator.GetBool("isAttacking");
        isLookingLeft = playerStats.animator.GetBool("isLookingLeft");
        isLookingRight = playerStats.animator.GetBool("isLookingRight");

        if (!isLookingLeft && !isLookingRight)
        {

        }
    }

    // Functions
    public void ProcessMove(Vector2 input)  // Will receive the input from the InputManager.cs and apply them to the character controler
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        //moveDirection.z = input.y;
        //controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        axisSpeeds.y += gravity * Time.deltaTime;
        if (isGrounded && axisSpeeds.y < 0)
        {
            axisSpeeds.y = gravity;
        }

        if (input.x <= -0.1)
        {
            playerStats.animator.SetBool("isLookingLeft", true);
            playerStats.animator.SetBool("isLookingRight", false);
            isIdle = false;
        }
        else if(input.x >= 0.1)
        {
            playerStats.animator.SetBool("isLookingRight", true);
            playerStats.animator.SetBool("isLookingLeft", false);
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }
        //controller.Move(playervelocity * Time.deltaTime);
        transform.Translate(moveDirection * speed * Time.deltaTime);
        //Debug.Log(playervelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("Jumping");
            rigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            playerStats.soundGame.PlayOneShot(playerStats.jump);    // here we send the audio clip of jumping to the game manager
                                                                    // to process it and play it on the general audio source
                                                                    //playervelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            isGrounded = false;
        }

        /*if (isGrounded)
        {
            axisSpeeds.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }*/
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            playerStats.animator.SetBool("isAttacking", true);
        }
        Debug.Log("Player attacked!");
        if (isAttacking)
        {

            playerStats.soundGame.PlayOneShot(playerStats.attack);  // here we send the audio clip of jumping to the game manager
                                                                    // to process it and play it on the general audio source
                                                                    //playervelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            playerStats.animator.SetBool("isAttacking", false);
        }
    }

    // Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            Debug.Log("Player touching ground or a platform!");
        }
    }
}
