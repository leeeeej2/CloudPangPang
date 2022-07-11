using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatCloud : MonoBehaviour
{
    public static int whiteCount = 0;
    public static int yellowCount = 0;
    public static int pinkCount = 0;
    public static int blueCount = 0;

    public static int totalCount = 0;
    public int ammoCount = 0;

    public int perCloud = 2;

    Color currentCol;

    GameObject original;
    GameObject cloud;
    GameObject ammo;

    private void Awake() {
        original = GameObject.Find("CloudCount");
        ammo = GameObject.Find("ammoCount");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "aircraft-A-A")
        {
            currentCol = GetComponent<MeshRenderer>().material.color;
            if(currentCol == makeCloud.white)
            {
                whiteCount++;
                cloud = original.transform.GetChild(0).gameObject;
                cloud.GetComponent<Text>().text = whiteCount.ToString();
            }
            else if(currentCol == makeCloud.yellow)
            {
                yellowCount++;
                cloud = original.transform.GetChild(1).gameObject;
                cloud.GetComponent<Text>().text = yellowCount.ToString();
            }
            else if(currentCol == makeCloud.pink)
            {
                pinkCount++;
                cloud = original.transform.GetChild(2).gameObject;
                cloud.GetComponent<Text>().text = pinkCount.ToString();
            }
            else if(currentCol == makeCloud.blue)
            {
                blueCount++;
                cloud = original.transform.GetChild(3).gameObject;
                cloud.GetComponent<Text>().text = blueCount.ToString();
            }

            totalCount++;
            if(totalCount%perCloud == 0)
            {
                ammoCount = (totalCount/perCloud);
                ammo.GetComponent<Text>().text = ammoCount.ToString();
            }
            //Debug.Log("collision");
            this.gameObject.SetActive(false);
            Score.score++;
            //Destroy(this);
        }

        //Debug.Log("hihi");
        //Destroy(other);
    }
}
