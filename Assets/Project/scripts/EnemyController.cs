using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the player on the left. 
public class EnemyController : MonoBehaviour
{
    public float speed = 1.75F;

    public float TOP_BOUND = 1.340353F;
    public float BOTTOM_BOUND = -1.245001F;
    Transform ball;
    Rigidbody2D ballRig2D;

    void Start()
    {
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        ballRig2D = ball.GetComponent<Rigidbody2D>();

        //checking x direction of the ball
        CpuMove();
       // stickMove();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void stickMove()
    {
        if (Input.GetKey(KeyCode.T))
        {
            //  Debug.Log("Vector3.up  :: " + Vector3.up );
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.G))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        ///TODO: turn into function.
        if (transform.position.y > TOP_BOUND)
        {
            Debug.Log("Does this get ran 111 ");
            transform.position = new Vector3(transform.position.x, TOP_BOUND, transform.position.z);
        }
        else if (transform.position.y < BOTTOM_BOUND)
        {
            Debug.Log("Does this get ran 222 ");
            transform.position = new Vector3(transform.position.x, BOTTOM_BOUND, transform.position.z);
        }
    }

    public void CpuMove()
    {
        if (ballRig2D.velocity.x < 0)
        {
            //checking y direction of ball
            if (ball.position.y < this.transform.position.y)
            {
                //move ball down if lower than paddle'
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (ball.position.y > this.transform.position.y)
            {
                //move ball up if higher than paddle
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if (transform.position.y > TOP_BOUND)
            {
                Debug.Log("Does this get ran 111 ");
                transform.position = new Vector3(transform.position.x, TOP_BOUND, transform.position.z);
            }
            else if (transform.position.y < BOTTOM_BOUND)
            {
                Debug.Log("Does this get ran 222 ");
                transform.position = new Vector3(transform.position.x, BOTTOM_BOUND, transform.position.z);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("other :: " + other);
    }

}
