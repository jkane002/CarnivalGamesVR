using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{
    //public GameObject ball;
    public GameObject ogBall;
    // 5 pts
    public SphereCollider leftYellow5;
    public SphereCollider rightYellow5;
    public SphereCollider midYellow5;
    // 10 pts
    public SphereCollider green10;
    // 1 pt
    public BoxCollider box1;

    public BoxCollider ballExit;
    Vector3 initBall;
    string currMsg = "Grab a ball!";


    //public int userTurns = 5;
    public int score = 0;

    private bool didBallExit = false;
    // Use this for initialization
    void Start()
    {

        //InstantiateBall();
        startGame();
    }

    public void startGame()
    {
        InitBallToss();
    }

    // Update is called once per frame
    void Update()
    {

        if (didBallExit)
        {
            Debug.Log("Ball left collider");
            didBallExit = false;
        }
    }

    void InitBallToss()
    {
        //newBallpreFab = GameObject.FindGameObjectWithTag("ballTossBall").GetComponent<GameObject>();
        //ball = GameObject.FindGameObjectWithTag("ballTossBall").GetComponent<GameObject>();
        //ogBall = GameObject.FindGameObjectWithTag("ballTossBall").GetComponent<GameObject>();

        initBall = ogBall.transform.position;
        //5pts
        leftYellow5 = GameObject.FindGameObjectWithTag("TopLeftRing").GetComponent<SphereCollider>();
        rightYellow5 = GameObject.FindGameObjectWithTag("TopRightRing").GetComponent<SphereCollider>();
        midYellow5 = GameObject.FindGameObjectWithTag("BotRing").GetComponent<SphereCollider>();
        // 10 pts
        green10 = GameObject.FindGameObjectWithTag("TopMidRing").GetComponent<SphereCollider>();
        // 1 pt
        box1 = GameObject.FindGameObjectWithTag("hollowCube").GetComponent<BoxCollider>();

        ballExit = GameObject.FindGameObjectWithTag("ballStand").GetComponent<BoxCollider>();

        ScoreTracker.ResetScore();
        ScoreTracker.ResetUserTurns();
        ScoreTracker.UpdateMessage(currMsg);
        //delete all balls with ballTossBall tag
        // spawn ball? but with what position? might affect InstantiateBall()
    }

    private void OnTriggerExit(Collider other)
    {
        //Transform newBallTransform = ;
        if (other.gameObject.tag == "ballTossBall" && ScoreTracker.GetUserTurns() > 0 && this.tag == "ballStand")
        {
            Debug.Log("Ball exiting");
            InstantiateBall();
            ScoreTracker.UpdateUserTurns(-1);

            didBallExit = true;
        }


    }

    public void InstantiateBall()
    {
        GameObject newBall = Instantiate(ogBall, initBall, Quaternion.identity);

       // Instantiate(ogBall,/* ogBall.transform*/ new Vector3(11.54f, 2.3f, 37.5f), Quaternion.identity);
        //ogBall.tag = "ballTossBall";
       
        newBall.transform.localScale = new Vector3(.25f, .25f, .25f);
        newBall.GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log("test");


        //Rigidbody ogBallRB = ogBall.AddComponent<Rigidbody>();
        //ogBallRB = ogBall.GetComponent<Rigidbody>();
        //Debug.Log(ogBallRB);
        //if (ogBallRB.isKinematic)
        //   ogBallRB.isKinematic = false;
        ////ogBallRB.isKinematic = false;
        ////ogBallRB.useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ballTossBall")
        {
            Debug.Log("Ball inside");
        }

        switch (this.tag)
        {
            case "TopLeftRing":
                Debug.Log("TopLeftRing");
                ScoreTracker.UpdateScore(5);
                ScoreTracker.UpdateMessage("You scored 5 points!");
                break;
            case "TopRightRing":
                Debug.Log("TopRightRing");
                ScoreTracker.UpdateScore(5);
                ScoreTracker.UpdateMessage("You scored 5 points!");
                break;
            case "BotRing":
                Debug.Log("BotRing");
                ScoreTracker.UpdateScore(5);
                ScoreTracker.UpdateMessage("You scored 5 points!");
                break;
            case "TopMidRing":
                Debug.Log("TopMidRing");
                ScoreTracker.UpdateScore(10);
                ScoreTracker.UpdateMessage("You scored 10 points!");
                break;
            case "hollowCube":
                Debug.Log("hollowCube");
                ScoreTracker.UpdateScore(1);
                ScoreTracker.UpdateMessage("You scored 1 point.");
                break;
        }
    }
}
