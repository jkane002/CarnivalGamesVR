using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballInstaitianteKnockDown : MonoBehaviour {
    public int MAXBALLS = 8;
    public int numOfBalls = 0;
    Vector3 initBall;
    public GameObject ball;
    GameObject newBall;
    public ball_toss b1;
    public Text countdown;
    public GameObject countdownCanvas;

    private List<GameObject> balls = new List<GameObject>();
	// Use this for initialization
	void Start () {
        initBall = ball.transform.position;
        balls.Add(ball);
        //createInit();
	}
	
	// Update is called once per frame
	void Update () {
        deleteCurrentBalls();
        if(MAXBALLS == numOfBalls)
        {
            b1.gameOver();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("NUM OF BALLS: " + numOfBalls);
        if(numOfBalls < MAXBALLS)
        {
            print("making another ball");
            //print("EXIT");
            //print("Num od balls " + numOfBalls);

            if (other.tag == "ballBottle0")
            {
                print("Going to start coroutine");
                StartCoroutine(startGame());


                newBall = Instantiate(ball, initBall, Quaternion.identity);
                newBall.GetComponent<Rigidbody>().isKinematic = false;
                newBall.name = "Ball" + numOfBalls;
                newBall.SetActive(true);
                newBall.tag = "ballBottle";
                balls.Add(newBall);
                numOfBalls++;
            } else if (other.tag == "ballBottle") {
                newBall = Instantiate(ball, initBall, Quaternion.identity);
                newBall.GetComponent<Rigidbody>().isKinematic = false;
                newBall.name = "Ball" + numOfBalls;
                newBall.SetActive(true);
                newBall.tag = "ballBottle";
                balls.Add(newBall);
                numOfBalls++;
            }
            b1.updateGameText();
        }
    }

    //private void createInit()
    //{
    //    print("CREATE INTI");
    //    newBall = Instantiate(ball, initBall, Quaternion.identity);
    //    newBall.GetComponent<Rigidbody>().isKinematic = false;
    //    newBall.name = "Ball" + numOfBalls;
    //    newBall.SetActive(true);
    //    balls.Add(newBall);
    //    numOfBalls++;
    //}

    private void deleteCurrentBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            //print("Balls we have is " + balls[i].name);
            if (balls[i].transform.position.y <= 0.5)
            {
                balls[i].SetActive(false);
            }
        }
    }

    IEnumerator startGame()
    {
        b1.deactivateHowTo();
        countdownCanvas.SetActive(true);
        print("Goning to start GAME COROUTINE");
        for (int i = 5; i > 0; i--)
        {
            print("Seconds: " + i);
            setCountDown(i);
            yield return new WaitForSeconds(1f);
        }
        //yield return new WaitForSeconds(5f);
        countdownCanvas.SetActive(false);
        b1.startingGame();
    }

    private void setCountDown(int i) {
        countdown.text = "" + i;
    }

}
