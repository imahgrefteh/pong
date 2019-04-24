using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float minXSpeed = 0.8f;
    public float maxXSpeed = 1.2f;
    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;
    public float difficultyMultiplier = 3.00f;
    // Start is called before the first frame update

    private Rigidbody2D ballRigidbody;
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed) * (Random.value > .5 ? -1 : 1),
         Random.Range(minYSpeed, maxYSpeed) * (Random.value > .5 ? -1 : 1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Limit")
        {
            //  Debug.Log("collide with limit");
            GetComponent<AudioSource>().Play();

            if (other.transform.position.y > transform.position.y && ballRigidbody.velocity.y > 0)
            {
                ballRigidbody.velocity = new Vector2(
                 ballRigidbody.velocity.x,
                 -ballRigidbody.velocity.y);
            }

            if (other.transform.position.y < transform.position.y && ballRigidbody.velocity.y < 0)
            {
                ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, -ballRigidbody.velocity.y);
            }
        }
        if (other.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();

            // Collided with the left paddle.
            if (ballRigidbody.velocity.x < 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }

            // Collided with the right paddle.
            else if (ballRigidbody.velocity.x > 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }
        }
    }
}