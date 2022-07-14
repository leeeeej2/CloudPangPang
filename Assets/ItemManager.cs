using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
    public GameObject[] clones;

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
        Debug.Log("PressBomB");

        clones = GameObject.FindGameObjectsWithTag("cloudsClone");
        foreach(var c in clones)
        {
            DestroyImmediate(c, true);
        }
    }

    public void PressSun()
    {
        EatCloud.stopYellow = false;
        EatCloud.yellowCount = 0;
    }
}
