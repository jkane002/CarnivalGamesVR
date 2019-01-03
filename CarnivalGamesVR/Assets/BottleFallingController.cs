using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFallingController : MonoBehaviour {
    public BottleFall1 bottle1;
    public BottleFall2 bottle2;
    public BottleFall3 bottle3;

    public bool bottleSetFall;
    public float timeSetFell;

    public int order;
    // Use this for initialization
    void Start()
    {
        bottleSetFall = false;
        timeSetFell = Time.deltaTime;
        order = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if(!bottleSetFall)
        {
            timeSetFell += Time.deltaTime;

            if (bottle1.fall && bottle2.fall && bottle3.fall)
            {
                bottleSetFall = true;
            }
        }
    }

    public void ResetBottles()
    {
        print("\tRESETING BOTTLES(BottleFallingController.cs)");
        bottle1.bottleReset();
        bottle2.bottleReset();
        bottle3.bottleReset();
        order = -1;
    }
}
