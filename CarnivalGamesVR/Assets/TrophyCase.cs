using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCase : MonoBehaviour {
    public prizeSetSmall smallPrizes;
    public prizeSetMedium mediumPrizes;
    public prizeSetLarge largePrizes;


    public Vector3 getnewPrizePosition(string prizeType)
    {
        switch(prizeType)
        {
            case "smallPrize":
                return smallPrizes.returnNextSpot();
            case "mediumPrize":
                return mediumPrizes.returnNextSpot();
            case "largePrize":
                return largePrizes.returnNextSpot();
            default:
                break;
        }

        return new Vector3(0, 0, 0);
    }
}
