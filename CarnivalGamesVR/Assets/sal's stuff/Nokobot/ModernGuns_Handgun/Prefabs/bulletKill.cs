using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletKill : MonoBehaviour {

    //public GameObject gun;
    //public gun gunScript;
    //bool duckDestroyed = false;
    // public GameObject game;
    //GameObject[] ducks;
    public static List<GameObject> ducks = new List<GameObject>();

    // Use this for initialization
    void Start () {

        //start_game game_script = game.GetComponent<start_game>();
        //duckDestroyed = false;
        //gunScript = gun.GetComponent<gun>();
    }
	
	// Update is called once per frame
	void Update () {

        if(timer.reset == true)
        {
            timer.reset = false;
            for(int i = 0; i < ducks.Count; ++i)
            {
                ducks[i].SetActive(true);
            }
        }
      
	}

    void OnCollisionEnter(Collision collision)
    {
        //if(game_script.triggerEntered == true)
        if(collision.transform.tag == "Duck")
        {
            if (timer.start == true)
            {
                ducks.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
                //Destroy(collision.gameObject);
                Static.points += 10;
                
            }
            //gunScript.hit();
            //Debug.Log("in here getting them kill");        
        }
    }
}
