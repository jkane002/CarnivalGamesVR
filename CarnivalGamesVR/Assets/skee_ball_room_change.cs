﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skee_ball_room_change : MonoBehaviour {
    public GameObject player;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("z"))
        {
                player.transform.position = new Vector3(-101, 5, 0);
                Debug.Log("Pressed z skee ball");
        }

        if (other.tag == "Player" && OVRInput.Get(OVRInput.Button.One))
        {
            player.transform.position = new Vector3(-101, 5, 0);
            Debug.Log("Pressed z skee ball");
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
