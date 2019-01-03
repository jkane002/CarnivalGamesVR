using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeSetMedium : MonoBehaviour {

    public locationEmpty p0;
    public locationEmpty p1;
    public locationEmpty p2;
    public locationEmpty p3;
    public locationEmpty p4;
    public locationEmpty p5;

    public locationEmpty[] set;

    // Use this for initialization
    void Start()
    {
        set = new locationEmpty[] { p0, p1, p2, p3, p4, p5 };
    }


    public Vector3 returnNextSpot()
    {
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i].getIsEmpty())
            {
                return set[i].location();
            }
        }
        Vector3 a = new Vector3(0, 0, 0);
        return a;
    }
}
