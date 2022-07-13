using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
    public void PressHeart()
    {
        EatCloud.stopPink = false;
        EatCloud.pinkCount = 0;
        if(HealthManager.lifeSystem < 3)
        {
            HealthManager.lifeSystem++;
        }
    }

    public void PressBomb()
    {
        EatCloud.stopBlue = false;
        EatCloud.blueCount = 0;
    }
}
