using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeSetSmall : MonoBehaviour {
    public locationEmpty p0;
    public locationEmpty p1;
    public locationEmpty p2;
    public locationEmpty p3;
    public locationEmpty p4;
    public locationEmpty p5;
    public locationEmpty p6;
    public locationEmpty p7;

    public locationEmpty[] set;

    void Start () {
		set = new locationEmpty[] { p0,p1,p2,p3,p4,p5,p6,p7};
    }

    public Vector3 returnNextSpot()
    {
        for(int i = 0; i < set.Length; i++)
        {
            print("set[" + i + "] = " + set[i].getIsEmpty());
        }

        for (int i = 0; i < set.Length; i++)
        {
            if(set[i].getIsEmpty())
            {
                print("Going to return function");
                return set[i].location();
            }
        }

        Vector3 a = new Vector3(0, 0, 0);
        return a;
    }
}
