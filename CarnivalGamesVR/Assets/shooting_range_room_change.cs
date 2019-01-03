using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_range_room_change : MonoBehaviour {
    public GameObject player;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("z"))
        {
                player.transform.position = new Vector3(0, 5, 101);
                Debug.Log("Pressed z shooting range");
        }
        if (other.tag == "Player" && OVRInput.Get(OVRInput.Button.One))
        {
            player.transform.position = new Vector3(0, 5, 101);
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
