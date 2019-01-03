using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCollision : MonoBehaviour {

    public Collider cubeCollider;
	
    // Use this for initialization
	void Start () {
        cubeCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision)
    {
        //Increase score by 1 pt
        //if userturn > 0
            //decrement user turn by 1
    }
}
