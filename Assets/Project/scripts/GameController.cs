using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ballPreFab;
    public Text score1Text;
    public Text score2Text;
    // Start is called before the first frame update
    private Ball currentBall;
    private int score1 = 0;
    private int score2 = 0;

    private const float scoreCoordinates = 2.67f;
    void Start()
    {
        //How we created the ball
        spawnBall();
    }


    void spawnBall()
    {
        GameObject ballInstance = Instantiate(ballPreFab, transform);
        currentBall = ballInstance.GetComponent<Ball>();
        currentBall.transform.position = Vector3.zero;

        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (currentBall != null)
        {
            //TODO: much better way to figure out where the paddle is. 
            if (currentBall.transform.position.x > scoreCoordinates)
            {
                score1++;
                Destroy(currentBall.gameObject);
                spawnBall();

            }
            else if (currentBall.transform.position.x < -scoreCoordinates)
            {
                score2++;
                Destroy(currentBall.gameObject);
                spawnBall();
            }
        }
    }
}
