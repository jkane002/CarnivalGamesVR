using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public GameObject game;
    
    public Text myScore;
    public Text rules;
    public int points;

	// Use this for initialization
	void Start () {
        myScore.text = "Score: ";
        rules.text = "HOWDY PARTNER! Welcome to duck\n" +
            "hunt V2!\n" +
            "Rules: There really is no rules! You only\n" +
            "got 60 seconds to shoot as many\n " +
            "ducks as you can! Are you ready!?!\n" +
            "Well press that button and ready up\n" +
            "Partner!";
	}
	
	// Update is called once per frame
	void Update () {
        
        gun game_script = game.GetComponent<gun>();
        //Debug.Log(game_script.points);

        myScore.text = "Score: " + Static.points;
        //myScore.text = "testing";
        
        
	}
}
