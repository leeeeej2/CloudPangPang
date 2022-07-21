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
    public static int ammoCount = 3;
    public int WhiteNum = 1;

    public static int perCloud = 2;

    public static bool stopPink = false;
    public int PinkNum = 1;
    public static bool stopBlue = false;
    public int BlueNum = 1;
    public static bool stopYellow = false;
    public int YellowNum = 1;
    
    Color currentCol;

    GameObject original;
    GameObject cloud;
    GameObject ammo;
    GameObject heart;
    GameObject bomb;
    GameObject sun;
    GameObject ammoText;
    GameObject ammoImage;

    private float time = 0f;
    private bool countTime = false;

    private void Awake() {
        original = GameObject.Find("CloudCount");
        ammo = GameObject.Find("ammoCount");
        heart = GameObject.Find("Giveheart");
        bomb = GameObject.Find("Bomb");
        sun = GameObject.Find("Sun");
        ammoText = GameObject.Find("ammoUpdate").transform.GetChild(0).gameObject;
        ammoImage = GameObject.Find("ammoUpdate").transform.GetChild(1).gameObject;
    }
    private void Start() {
        //ammoupdated.SetActive(false);
    }
    private void Update() {
        //if(countTime)
        {
            //time += Time.deltaTime;
           // Debug.Log("CountTime: " + time);
        }

        //if(time > 2f)
        {
            //Debug.Log("timeOver");
            //countTime = false;
            //time = 0f;
        }

        if(pinkCount == 0)
        {
            cloud = original.transform.GetChild(2).gameObject;
            cloud.GetComponent<Text>().text = pinkCount.ToString();
            heart.transform.position = new Vector3(heart.transform.position.x, -236, heart.transform.position.z);
        }

        if(blueCount == 0)
        {
            cloud = original.transform.GetChild(3).gameObject;
            cloud.GetComponent<Text>().text = blueCount.ToString();
            bomb.transform.position = new Vector3(bomb.transform.position.x, -236, bomb.transform.position.z);
        }
        if(yellowCount == 0)
        {
            cloud = original.transform.GetChild(1).gameObject;
            cloud.GetComponent<Text>().text = yellowCount.ToString();
            sun.transform.position = new Vector3(sun.transform.position.x, -236, sun.transform.position.z);
        }
        if(whiteCount == 0 /*&& !countTime*/)
        {
            //if(!countTime)
            {
                ammoText.transform.position = new Vector3(ammoText.transform.position.x, -236, ammoText.transform.position.z);
                ammoImage.transform.position = new Vector3(ammoImage.transform.position.x, -236, ammoImage.transform.position.z);
            }
        }

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
                if(whiteCount == WhiteNum)
                {
                    Debug.Log("11111111111");
                    countTime = true;
                    ammoText.transform.position = new Vector3(ammoText.transform.position.x, 0, ammoText.transform.position.z);
                    ammoImage.transform.position = new Vector3(ammoImage.transform.position.x, 0, ammoImage.transform.position.z);

                    whiteCount = 0;
                    cloud.GetComponent<Text>().text = whiteCount.ToString();
                    ammoCount += 3;
                    ammo.GetComponent<Text>().text = ammoCount.ToString();
                }
            }
            else if(currentCol == makeCloud.yellow)
            {
                if(!stopYellow)
                {
                    yellowCount++;
                    cloud = original.transform.GetChild(1).gameObject;
                    cloud.GetComponent<Text>().text = yellowCount.ToString();
                    if(yellowCount == YellowNum)
                    {
                        stopYellow = true;
                        sun.transform.position = new Vector3(sun.transform.position.x, 0, sun.transform.position.z);
                    }
                }

            }
            else if(currentCol == makeCloud.pink)
            {
                if(!stopPink)
                {
                    pinkCount++;
                    cloud = original.transform.GetChild(2).gameObject;
                    cloud.GetComponent<Text>().text = pinkCount.ToString();
                    if(pinkCount == PinkNum)
                    {
                        stopPink = true;
                        heart.transform.position = new Vector3(heart.transform.position.x, 0, heart.transform.position.z);
                    }
                }
                
            }
            else if(currentCol == makeCloud.blue)
            {
                if(!stopBlue)
                {
                    blueCount++;
                    cloud = original.transform.GetChild(3).gameObject;
                    cloud.GetComponent<Text>().text = blueCount.ToString();
                    if(blueCount == BlueNum)
                    {
                        stopBlue = true;
                        bomb.transform.position = new Vector3(bomb.transform.position.x, 0, bomb.transform.position.z);
                    }
                }

            }

            //totalCount++;
            //if(totalCount%perCloud == 0)
            {
                //ammoCount = (totalCount/perCloud);
                //ammo.GetComponent<Text>().text = ammoCount.ToString();
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
