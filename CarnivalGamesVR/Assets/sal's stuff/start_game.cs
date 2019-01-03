using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_game : MonoBehaviour {

    public GameObject player;
    public orbit orbitScript;
    public orbit orbitscript1;
    public specialOrbit orbitscript2;
    public orbit orbitscript3;
    public timer timer1;
    public bool triggerEntered = false;
    bool pointsAtZero = false;
    public static float time;
    //public GameObject bulletPoints;
    

    // Use this for initialization
    void Start () {
        //points = 0;
        orbitScript.enabled = false;
        orbitscript1.enabled = false;
        orbitscript2.enabled = false;
        orbitscript3.enabled = false;
        timer1.enabled = false;
        triggerEntered = false;
        pointsAtZero = false;
        timer.start = false;
       
    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.Button.Two) && (triggerEntered == true) && (timer.timecount < 30))
        {
            orbitScript.enabled = true;
            orbitscript1.enabled = true;
            orbitscript2.enabled = true;
            orbitscript3.enabled = true;
            timer1.enabled = true;
            pointsAtZero = true;
            timer.start = true;
        }
        else if(timer.timecount > 30)
        {
            timer.start = false;
            orbitScript.enabled = false;
            orbitscript1.enabled = false;
            orbitscript2.enabled = false;
            orbitscript3.enabled = false;
            timer1.enabled = false;
            Static.points = Static.points * 1;
        }
        else if(timer.timecount > 30 && triggerEntered == true)
        {
            timer.reset = true;
            triggerEntered = false;
        }
        else
        {
            if(pointsAtZero == false)
            {
                Static.points = 0;
                
            }
            
        }
        

        //bulletKill bullet_script = bulletPoints.GetComponent<bulletKill>();
        //points += bullet_script.killpoints;
        //Debug.Log(points);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = true;
        }
    
    }

    //private void oncollisionenter(collision collision)
    //{
    //    if(collision.transform.tag == "duck")
    //    {
    //        destroy(collision.gameobject);
    //    }
    //}

}
