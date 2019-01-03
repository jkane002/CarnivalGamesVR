using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    static public float timecount;
    static public bool start;
    static public bool reset;
    public Text theTime;

	// Use this for initialization
	void Start () {

        timecount = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {

        timecount += Time.deltaTime;
        theTime.text = "Time: " + timecount;
		
	}
}
