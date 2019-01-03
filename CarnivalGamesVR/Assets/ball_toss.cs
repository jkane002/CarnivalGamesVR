using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ball_toss : MonoBehaviour {

    //BottleFall bf_Script;
    public Light spotLight_1;
    public Light spotLight_2;
    public Light spotLight_3;

    public BottleFallingController bottleSet1;
    public BottleFallingController bottleSet2;
    public BottleFallingController bottleSet3;

    public ballInstaitianteKnockDown bik;

    public GameObject howToText;
    public GameObject duringGameText;

    public Text duringGameText_Points;
    public Text duringGameText_BallsLeft;

    public GameObject gameOVerText;

    public Text endGameText_Congrats;
    public Text endGameText_Points;

    public GameObject walls;
    public GameObject prizes;

    public GameObject bSet1;
    public GameObject bSet2;
    public GameObject bSet3;


    Light[] spotLights;
    int[] spotLights_on;
    object[] parms;
    Boolean[] ball_Set_Hit;

    float interval;
    Boolean pressedF;
    Boolean inOnOffLight;

    public float time;

    bool gameOverBool;

    System.Random rnd;

    int SIZEGAME = 3;

    int points;

    int orderFell;
    int SEED;

    /*
     * Intialize variables
     */
    private void initVars() {
        spotLight_1.intensity = 0;
        spotLight_2.intensity = 0;
        spotLight_3.intensity = 0;

        spotLights_on = new int[1];
        spotLights = new Light[3];
        spotLights[0] = spotLight_1;
        spotLights[1] = spotLight_2;
        spotLights[2] = spotLight_3;

        pressedF = false;

        rnd = new System.Random();

        points = 0;

        SEED = 30;

        orderFell = 0;
        gameOverBool = false;

    }

    /*
     * At Start of game intialize variables
     */
    private void Start()
    {
        initVars();
        initHowTo();
    }

    private void initHowTo()
    {
        howToText.SetActive(true);
        deactivateForText();
    }

    public void deactivateHowTo()
    {
        howToText.SetActive(false);
        //reactivateForGame();
    }

    private void deactivateForText()
    {
        prizes.SetActive(false);
        bSet1.SetActive(false);
        bSet2.SetActive(false);
        bSet3.SetActive(false);
    }

    private void reactivateForGame()
    {
        prizes.SetActive(true);
        bSet1.SetActive(true);
        bSet2.SetActive(true);
        bSet3.SetActive(true);

    }

    private void Update()
    {
        int pastPoints = 0;

        if(pastPoints != points)
        {
            //print("Current points is " + points);
            pastPoints = points;
        }
    }

    /*
     * When player is in collider range and presses F game will start
     */

    private void OnTriggerStay(Collider other)
    {
        //if(OVRInput.Get(OVRInput.Button.Three))
        //{
        //    if (!pressedF)
        //    {
        //        StartCoroutine(startGame());
        //        pressedF = true;
        //    }
        //    else if (pressedF)
        //    {
        //        print("Pressnig F again will restart the game!");
        //        pressedF = false;
        //    }
        //}
    }

    public void startingGame()
    {
        StartCoroutine(startGame());
    }

    private void initGameText()
    {
        duringGameText.SetActive(true);
        updateGameText();
    }


    public void updateGameText()
    {
        duringGameText_Points.text = "Points: " + points;
        duringGameText_BallsLeft.text = "Balls Left: " + (bik.MAXBALLS - bik.numOfBalls) ;
    } 

    private IEnumerator startGame()
    {
        print("Starting Game");
        reactivateForGame();
        initGameText();
        yield return new WaitForSeconds(1f);
        for (int l = 1; l <= SIZEGAME; l++)
        {
            print("\t Starting pattern of length: " + l);
            //Create array for pattern length
            spotLights_on = new int[l];
            //Populate array with random number from 0-2
            bool[] lights = { false, false, false };
            spotLights_on[0] = rnd.Next(0, 3);
            lights[spotLights_on[0]] = true;
            for (int i = 1; i < l; i++)
            {
                spotLights_on[i] = rnd.Next(0, 3);

                while (lights[spotLights_on[i]])
                {
                    spotLights_on[i] = rnd.Next(0, 3);
                }

                lights[spotLights_on[i]] = true;
            }

            lights = new bool[] {false, false, false};

            //Start Coroutine that will display lights in pattern order
            yield return StartCoroutine(startLightPattern(spotLights_on));
            //Wait for player to attempt
            yield return StartCoroutine(playersTurn(spotLights_on));
            print("\t Ending pattern of length: " + l);
            if (gameOverBool)
                break;
            yield return StartCoroutine(resetBottlesCorutine());
            resetBottles();
        }
        yield return new WaitForSeconds(0.5f);
        congrats();
        print("Ending Game");
    }

    private void congrats()
    {
        duringGameText.SetActive(false);
        gameOVerText.SetActive(true);
        endGameText_Congrats.text = "Congrats!";
        endGameText_Points.text = "Points: " + points;
    }

    /*
     *  Will show the pattern on the lights
     */
    IEnumerator startLightPattern(int[] p) {
        print("\t\t Starting Light Pattern");
        //Iterate through pattern length
        for (int i = 0; i < p.Length; i++)
        {
            print("\t\tTurning on Light #" + p[i]);
            spotLights[p[i]].intensity = 2;
            yield return new WaitForSeconds(1f);
            spotLights[p[i]].intensity = 0;
            yield return new WaitForSeconds(.5f);
        }
        print("\t\t Ending Light Pattern");
    }


    IEnumerator playersTurn(int[] pattern)
    {
        print("\t\t Player's Turn for length " + pattern.Length);

        while (!setsDown(pattern.Length))
        {
            //updateGameText();
            yield return new WaitForSeconds(0.01f);
        }
        //updateGameText();
        if (!patternCorrect(pattern))
        {
            print("\t\tGAME OVER!");
            //gameOverBool = true;
            gameOver();
        }
        //updateGameText();
        print("\t\t End player's Turn for length " + pattern.Length);
    }

    public void gameOver()
    {
        print("\t\t\tQUITING");
        print("Total POINTS END: " + points);
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //        Application.Quit();
        //#endif
        //howToText.SetActive(true);
        gameOverBool = true;
        deactivateForText();
        gameOverSet();
    }

    private void gameOverSet()
    {
        duringGameText.SetActive(false);
        gameOVerText.SetActive(true);
        endGameText_Points.text = "Points: " + points;
    }

    private bool setsDown(int sets)
    {
        int setDown = 0;

        if (bottleSet1.bottleSetFall)
        {
            //print("Bottle set 1 fell");
            setDown++;
            if(bottleSet1.order == -1)
            {
                bottleSet1.order = orderFell;
                orderFell++;
            }
        }

        if (bottleSet2.bottleSetFall)
        {
            //print("Bottle set 2 fell");
            setDown++;
            if(bottleSet2.order == -1)
            {
                bottleSet2.order = orderFell;
                orderFell++;
            }

        }

        if (bottleSet3.bottleSetFall)
        {
            //print("Bottle set 3 fell");
            setDown++;
            if(bottleSet3.order == -1)
            {
                bottleSet3.order = orderFell;
                orderFell++;
            }

        }

        if (setDown >= sets) 
            return true;

        return false;
    }

    private bool patternCorrect(int[] pattern) {
        BottleFallingController[] bottleSets = { bottleSet1, bottleSet2, bottleSet3 };
        int[] num = { 0, 1, 2 };


        for(int i = 0; i < bottleSets.Length; i++)
        {
            print("Bottle #" + i + " is order" + bottleSets[i].order);
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            if (bottleSets[pattern[i]].order != i)
                return false;
        }

        for(int i = 0; i < pattern.Length; i++)
        {
            bottleSets[i].order = -1;
        }

        incrementPoints(pattern.Length);
        return true;
    }

    private void resetBottles()
    {
        print("\tRESETING BOTTLES(ball_toss.cs)");
        bottleSet1.ResetBottles();
        bottleSet2.ResetBottles();
        bottleSet3.ResetBottles();
        orderFell = 0;
    }

    IEnumerator resetBottlesCorutine()
    {
        yield return new WaitForSeconds(3f);
        resetBottles();
    }

    private void incrementPoints(int level)
    {
        points += (level * 10);
    }

}
