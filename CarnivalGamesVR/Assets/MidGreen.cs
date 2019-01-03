using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGreen : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ballTossBall")
        {
            ScoreTracker.UpdateScore(10);
            ScoreTracker.UpdateMessage("You scored 10 points!");
        }

    }
}
