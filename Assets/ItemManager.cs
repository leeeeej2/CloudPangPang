using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{ 
    public GameObject[] clones;

    public void PressHeart()
    {
        SoundManager.instance.PlaySfx("Pop");
        EatCloud.stopPink = false;
        EatCloud.pinkCount = 0;
        if(HealthManager.lifeSystem < 3)
        {
            HealthManager.lifeSystem++;
        }
    }

    public void PressBomb()
    {
        int count = 0;

        SoundManager.instance.PlaySfx("Pop");
        EatCloud.stopBlue = false;
        EatCloud.blueCount = 0;
        Debug.Log("PressBomB");

        clones = GameObject.FindGameObjectsWithTag("cloudsClone");
        foreach(var c in clones)
        {
            count++;
            DestroyImmediate(c, true);
        }

        Score.score += count;
    }

    public void PressSun()
    {
        SoundManager.instance.PlaySfx("Pop");
        EatCloud.stopYellow = false;
        EatCloud.yellowCount = 0;

        MoveScene.GoFeverTime();
    }
}
