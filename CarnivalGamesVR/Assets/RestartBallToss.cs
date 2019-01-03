using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBallToss : MonoBehaviour {

    string currMessage = "Grab a ball!";
    public GameObject ogBall;
    public spawnBalls sb;
    Vector3 initBall;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (ScoreTracker.GetUserTurns() == 0) {
        //    InstantiateBall();
        //}
	}

    private void OnTriggerEnter(Collider other)
    {
        ////resets score, message, userturns
        //// deletes all balls from prev turn
        //ScoreTracker.ResetScore();
        //ScoreTracker.UpdateMessage(currMessage);
        //ScoreTracker.ResetUserTurns();
        //var clones = GameObject.FindGameObjectsWithTag("ballTossBall");
        //foreach (var clone in clones)
        //{
        //    Destroy(clone);
        //}
        //Destroy(other);
        print("Resetaring");
        sb.startGame();
    }

    void InstantiateBall() {
        GameObject newBall = Instantiate(ogBall, new Vector3(11.54f, 2.2f, 30.5f), Quaternion.identity);

        newBall.transform.localScale = new Vector3(.25f, .25f, .25f);
        newBall.GetComponent<Rigidbody>().isKinematic = false;
    }
}
