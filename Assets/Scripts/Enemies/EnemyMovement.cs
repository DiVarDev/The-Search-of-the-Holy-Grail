using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables
    [Header("Enemy Settings")]
    // To control the speed at which the enemy moves
    public float speed = 2f;
    // Minimum distance to go to the left
    public float minimumX;
    // Minimum distance to go to the right
    public float maximumX;
    // To control the direction which the enemy goes
    public bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Functions
    public void Move()
    {
        // Moves the enemy in the correct direction according to the state of the movingRight variable
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Here we control when the enemy reaches the minimum and maximum distances we allow it to go
        // then we set the movingRight variable acordingly
        if (transform.position.x >= maximumX)
        {
            movingRight = false;
        }
        else if (transform.position.x <= minimumX)
        {
            movingRight = true;
        }
    }
}
