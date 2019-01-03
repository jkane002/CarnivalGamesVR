using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidYellow : MonoBehaviour {



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ballTossBall")
        {
            ScoreTracker.UpdateScore(5);
            ScoreTracker.UpdateMessage("You scored 5 points!");
        }

    }
}
