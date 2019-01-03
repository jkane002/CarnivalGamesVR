using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour {
    public int timeRemaining = 3;

    void countDwon()
    {
        timeRemaining--;
        print(timeRemaining);

        if(timeRemaining <= 0)
        {
            doThis();

            CancelInvoke("countDown");
            timeRemaining= 3;
            print("Reset time");
        }
    }

    void doThis()
    {
        print("Pressed Button");
    }

    public void MouseOver()
    {
        InvokeRepeating("countDown", 1, 1);
    }

    public void MouseExit()
    {
        CancelInvoke("countDown");
        timeRemaining = 3;
    }

}
