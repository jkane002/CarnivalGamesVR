using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prizemove : MonoBehaviour {
    public TrophyCase trophyCase;
    private Vector3 newPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //print("On Trigger Stay " + other.tag);
        if (other.tag == "smallPrize" || other.tag == "mediumPrize" || other.tag == "largePrize")
        {
            //print("On Trigger Stay PrizeMove");
            newPos = trophyCase.getnewPrizePosition(other.tag);

            other.transform.position = newPos +  new Vector3(0, 2.25f, 0);
        }
    }
}
