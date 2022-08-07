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
    GameObject TextTrans;
    GameObject ImageTrans;

    private float time = 0f;
    static bool countTime = false;

    private void Awake() {
        original = GameObject.Find("CloudCount");
        ammo = GameObject.Find("ammoCount");
        heart = GameObject.Find("Giveheart");
        bomb = GameObject.Find("Bomb");
        sun = GameObject.Find("Sun");
        ammoText = GameObject.Find("Plus");
        ammoImage = GameObject.Find("AmmoUpdate");
        TextTrans = GameObject.Find("PlusTransform");
        ImageTrans = GameObject.Find("AmmoTransform");
    }
    private void Start() {
        //ammoupdated.SetActive(false);

        cloud = original.transform.GetChild(0).gameObject;
        cloud.GetComponent<Text>().text = whiteCount.ToString();

        cloud = original.transform.GetChild(2).gameObject;
        cloud.GetComponent<Text>().text = pinkCount.ToString();

        cloud = original.transform.GetChild(3).gameObject;
        cloud.GetComponent<Text>().text = blueCount.ToString();

        cloud = original.transform.GetChild(1).gameObject;
        cloud.GetComponent<Text>().text = yellowCount.ToString();

        if (yellowCount == YellowNum)
        {
            stopYellow = true;
            sun.transform.position = new Vector3(sun.transform.position.x, 0, sun.transform.position.z);
        }

        if (pinkCount == PinkNum)
        {
            stopPink = true;
            heart.transform.position = new Vector3(heart.transform.position.x, 0, heart.transform.position.z);
        }

        if (blueCount == BlueNum)
        {
            stopBlue = true;
            bomb.transform.position = new Vector3(bomb.transform.position.x, 0, bomb.transform.position.z);
        }
    }
    private void Update() {

       // Debug.Log("count " + countTime);
        if(countTime)
        {
           time += Time.deltaTime;
           //Debug.Log("CountTime: " + time);
        }

        if(time > 1.2f)
        {
            //Debug.Log("timeOver");
            countTime = false;
            time = 0f;
        }

        cloud = original.transform.GetChild(0).gameObject;
        cloud.GetComponent<Text>().text = whiteCount.ToString();

        cloud = original.transform.GetChild(2).gameObject;
        cloud.GetComponent<Text>().text = pinkCount.ToString();

        cloud = original.transform.GetChild(3).gameObject;
        cloud.GetComponent<Text>().text = blueCount.ToString();

        cloud = original.transform.GetChild(1).gameObject;
        cloud.GetComponent<Text>().text = yellowCount.ToString();

        if (pinkCount == 0)
        {
            heart.transform.position = new Vector3(heart.transform.position.x, -236, heart.transform.position.z);
        }

        if(blueCount == 0)
        {
            bomb.transform.position = new Vector3(bomb.transform.position.x, -236, bomb.transform.position.z);
        }
        if(yellowCount == 0)
        {
            sun.transform.position = new Vector3(sun.transform.position.x, -236, sun.transform.position.z);
        }
        if(whiteCount == 0 && !countTime)
        {
            //if(!countTime)
            {
                ammoText.transform.position = new Vector3(TextTrans.transform.position.x, -236, TextTrans.transform.position.z);
                ammoImage.transform.position = new Vector3(ImageTrans.transform.position.x, -236 , ImageTrans.transform.position.z);
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
                //cloud = original.transform.GetChild(0).gameObject;
                //cloud.GetComponent<Text>().text = whiteCount.ToString();
                if(whiteCount == WhiteNum)
                {
                    //Debug.Log("11111111111");
                    countTime = true;
                    ammoText.transform.position = new Vector3(TextTrans.transform.position.x, TextTrans.transform.position.y, TextTrans.transform.position.z);
                    ammoImage.transform.position = new Vector3(ImageTrans.transform.position.x, ImageTrans.transform.position.y , ImageTrans.transform.position.z);

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
                    //cloud = original.transform.GetChild(1).gameObject;
                    //cloud.GetComponent<Text>().text = yellowCount.ToString();
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
                    //cloud = original.transform.GetChild(2).gameObject;
                    //cloud.GetComponent<Text>().text = pinkCount.ToString();
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
                    //cloud = original.transform.GetChild(3).gameObject;
                    //cloud.GetComponent<Text>().text = blueCount.ToString();
                    if(blueCount == BlueNum)
                    {
                        stopBlue = true;
                        bomb.transform.position = new Vector3(bomb.transform.position.x, 0, bomb.transform.position.z);
                    }
                }

            }

            //Debug.Log("collision");
            this.gameObject.SetActive(false);
            Score.score++;
            //Destroy(this);
        }
    }
}
