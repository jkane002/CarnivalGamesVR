using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFall2 : MonoBehaviour { 
    private Vector3 initPos;
    private Quaternion initRot;
    public bool fall;

    private void Start()
    {
        initPos = this.transform.position;
        initRot = this.transform.rotation;
        //print("Init pos x: " + initPos.x + " y: " + initPos.y + " z: " + initPos.z);
        fall = false;
    }

    private void Update()
    {
        if (!fall)
        {
            if (this.transform.localPosition.y <= 0)
            {
                //print("Bottle on ground");
                fall = true;
            }
            else if (this.transform.localRotation.x >= 17 || this.transform.localRotation.z >= 17)
            {
                //print("Bottle on ground");
                fall = true;
            }
        }
    }

    public void bottleReset()
    {
        print("\tRESETING BOTTLES(bottle2.cs)");
        this.transform.position = initPos;
        this.transform.rotation = initRot;
    }

}
