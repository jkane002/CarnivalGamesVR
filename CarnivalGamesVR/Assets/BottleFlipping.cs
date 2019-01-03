using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFlipping : MonoBehaviour {
    public GameObject bottle;
    Rigidbody rb;
    int i = 0;
    private void Awake()
    {
        rb = bottle.GetComponent<Rigidbody>();
        print(rb);
    }

    public void bottleHitWithForce(float force)
    {
        rb.AddForce(Vector3.forward * force);
    }

    private void Update()
    {
        if (i == 30)
            bottleHitWithForce(20);
        i++;
    }

    private void OnCollisionEnter(Collision collision)
    {

        print("COLLISION ENTER");
        bottleHitWithForce(10);
    }
}
