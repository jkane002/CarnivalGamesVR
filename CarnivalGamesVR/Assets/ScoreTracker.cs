using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    static public Text scoreText;
    static public Text messageText;
    static public Text turnsText;
    static public int currScore = 0;
    static public int userTurns = 5;
    static public string currMessage = "Grab a ball!";
    static public string turnsMessage = "" + userTurns + " turns left";

  //  static public OVRGrabbable ovrgrabbie;

    // Use this for initialization
    void Start()
    {
        //ovrgrabbie.enabled = false;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        messageText = GameObject.FindGameObjectWithTag("MessageText").GetComponent<Text>();
        turnsText = GameObject.FindGameObjectWithTag("TurnsText").GetComponent<Text>();

        UpdateScore(currScore);
        UpdateMessage(currMessage);
        UpdateUserTurns(0);

    }

    // Update is called once per frame
    void Update() { }

    public static void UpdateScore(int addedValue)
    {
        currScore += addedValue;
        scoreText.text = "Total Score: " + currScore;
    }
    public static void UpdateMessage(string msg)
    {
        currMessage = msg;
        messageText.text = currMessage;
    }

    public static void UpdateUserTurns(int turns)
    {
        userTurns += turns;
        if (userTurns == 0)
        {
            messageText.text = "Play again?";
            // if score is >10 big prize
            // if score 5 > x >= 10 med prize
            // if score == 5 small
            // if score < 5 no prize
            if (currScore > 10)
            {
                turnsText.text = "You won a Teddy Bear!";
                //ovrgrabbie.enabled = true;

            }
            else if (currScore > 5 && currScore <= 10)
            {
                turnsText.text = "You won a medium prize!";
            }
            else if (currScore == 5)
            {
                turnsText.text = "You won a small prize!";
            }
            else if(currScore < 5)
            {
                turnsText.text = "No luck this time :(";
            }
        }
        else
            turnsText.text = "" + userTurns + " turns left";
    }

    public static int GetUserTurns()
    {
        return userTurns;
    }

    public static void ResetScore()
    {
        currScore = 0;
    }

    public static void ResetUserTurns()
    {
        userTurns = 5;
    }
}
