using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    public int killpoints;
    public bulletKill bullet_script;
    public GameObject theBullet;

	// Use this for initialization
	void Start () {
        bullet_script = theBullet.GetComponent<bulletKill>();
        killpoints = 0;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    //public void hit()
    //{
    //    killpoints += 10;
    //}
}
