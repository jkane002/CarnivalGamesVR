using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    int p;
	// Use this for initialization
	void Start () {
        p = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hit()
    {
        p++;
    }
}
