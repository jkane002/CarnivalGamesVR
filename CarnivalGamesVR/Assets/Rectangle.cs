using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : MonoBehaviour {

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
            ScoreTracker.UpdateScore(1);
            ScoreTracker.UpdateMessage("You scored 1 point.");
        }
    }
}
