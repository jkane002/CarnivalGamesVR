using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationEmpty : MonoBehaviour {
    private bool empty = true;
	// Use this for initialization
	void Start () {
        empty = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getIsEmpty()
    {
        return empty;
    }

    public void setIsEmpty(bool t)
    {
        empty = t;
    }

    public Vector3 location() {
        return this.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Entering Trigger tag is: " + other.tag);
        if (other.tag == "smallPrize" || other.tag == "mediumPrize" || other.tag == "largePrize")
        {
            print("Prize Entered slot");
            empty = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "smallPrize" || other.tag == "mediumPrize" || other.tag == "largePrize")
        {
            empty = true;
        }
    }
}
