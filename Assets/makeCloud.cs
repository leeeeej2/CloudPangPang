using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cloud;
    //public GameObject cloud2;
    public GameObject mainObject;
    public GameObject mainObject2;

    public float xMax = -15f;
    public float xMin = -50f;

    public float yMax = 0;
    public float yMin = 25f;

    public float zMax = 25f;
    public float zMin = 30f;

    public float timer = 0;
    public float timeDiff = 1.5f;
    public float destoryTime = 10.0f;
    public float destoryOffset = 5f;

    float xCloudRangeMax;
    float xCloudRangeMin;

    float yCloudRangeMax;
    float yCloudRangeMin;

    float destroyLocation;
    public static GameObject newCloud;

    Vector3 changePosition;

    public static Color white;
    public static Color yellow;
    public static Color pink;
    public static Color blue;

    public Color[] myColors;
    public Color pickColor;

    int colorPer = 0;

    public int whitePer = 35;  //35
    public int pinkPer = 65;   //30
    public int bluePer = 90;   //25
    public int yellowPer = 100; //10
    //public Renderer myRenderer;


    private void Awake() {
        white = new Color(1f, 1f, 1f, 1f);
        yellow = new Color(1f, 0.835f, 0.454f, 1f);
        pink = new Color(1f, 0.686f, 1f, 1f);
        blue = new Color(0.431f, 0.666f, 1f, 1f);
    }

    void Start()
    {
        myColors[0] = white;
        myColors[1] = yellow;
        myColors[2] = pink;
        myColors[3] = blue;

        float xRange = 2 * Camera.main.orthographicSize;//2 * (Screen.height / 10) / 2;
        float yRange = xRange * Camera.main.aspect;

        float xOffset = xOffset = xRange + transform.localScale.x;
        float yOffset = yOffset = (yRange / 2) - (transform.localScale.y);

        Vector3 ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        xCloudRangeMax = mainObject.transform.position.x + xOffset - 1;
        xCloudRangeMin = mainObject.transform.position.x - xOffset + 1;

        yCloudRangeMax = mainObject.transform.position.y + yOffset - 1;
        yCloudRangeMin = mainObject.transform.position.y - yOffset + 1;

        destroyLocation = mainObject2.transform.position.z;

        //Debug.Log("destroy location");
        //Debug.Log(destroyLocation);

        //Debug.Log("x max");
        //Debug.Log(xCloudRangeMax);
        //Debug.Log("x min");
        //Debug.Log(xCloudRangeMin);
        //Debug.Log("y max");
        //Debug.Log(yCloudRangeMax);
        //Debug.Log("y min");
        //Debug.Log(yCloudRangeMin);
        //myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //int whatType = 0;

        if(timer > timeDiff)
        {
            //x -10 ~ 10
            //y -15 ~ 15
        
            //whatType = Random.Range(0, 2);

            //if(whatType == 0)
            //{
                newCloud = Instantiate(cloud);
            //}

            //if(whatType == 1)
            //{
            //    newCloud = Instantiate(cloud2);
            //}
            colorPer = Random.RandomRange(0, 100);

            //pickColor = myColors[Random.Range(0, myColors.Length)];

            if(colorPer < whitePer)
            {
                pickColor = myColors[0];
            }
            else if(colorPer < pinkPer)
            {
                pickColor = myColors[2];
            }
            else if(colorPer < bluePer)
            {
                pickColor = myColors[3];
            }
            else
            {
                pickColor = myColors[1];
            }

            newCloud.GetComponent<MeshRenderer>().material.color = pickColor;

            newCloud.gameObject.tag = "cloudsClone";
            //Debug.Log("" + newCloud.gameObject.tag);

            Vector3 mainPosition = mainObject.transform.position;
            Vector3 newPosition = new Vector3(Random.Range(xCloudRangeMin, xCloudRangeMax), Random.Range(yCloudRangeMin, yCloudRangeMax), Random.Range(zMin, zMax));

            //newCloud.gameObject.SetActive(false);

            newCloud.transform.position = newPosition;
            newCloud.transform.rotation = new Quaternion(0, 180, 0, 0);

            BoxCollider hihi = newCloud.GetComponent<BoxCollider>();

            float xOffsetCloud = newPosition.x - hihi.center.x;
            float yOffsetCloud = newPosition.y - hihi.center.y;
            float zOffsetCloud = newPosition.z - hihi.center.z;

            //Debug.Log("new cloud position : " + newCloud.transform.position);
            //Debug.Log("first collider center : " + hihi.center);
            //Debug.Log("x offset : " + xOffsetCloud + "y offset : " + yOffsetCloud);

            //usually x is big and y is small


            if (xOffsetCloud < 0)
            {
                //changePosition.x = hihi.center.x + xOffsetCloud; ///
                changePosition.x = newPosition.x - (xOffsetCloud  / 8); ///
                //Debug.Log("x change + : " + changePosition.x);
            }
            else
            {
                //changePosition.x = hihi.center.x - xOffsetCloud; 
                changePosition.x = newPosition.x + (xOffsetCloud / 8); 
                //Debug.Log("x change - : " + changePosition.x);
            }

            if (yOffsetCloud < 0)
            {
                //changePosition.y = hihi.center.y + yOffsetCloud;/////
                changePosition.y = newPosition.y - (yOffsetCloud / 5.5f);/////
                //Debug.Log("y change + : " + changePosition.y);
            }
            else
            {
                //changePosition.y = hihi.center.y + yOffsetCloud;
                changePosition.y = newPosition.y + (yOffsetCloud / 5.5f);
                //Debug.Log("y change - : " + changePosition.y);
            }

            if (zOffsetCloud < 0)
            {
                //changePosition.y = hihi.center.y + yOffsetCloud;/////
                changePosition.z = newPosition.z - (zOffsetCloud / 8);/////
                //Debug.Log("z change + : " + changePosition.z);
            }
            else
            {
                //changePosition.y = hihi.center.y + yOffsetCloud;
                changePosition.z = newPosition.z + (zOffsetCloud / 8);
                //Debug.Log("z change - : " + changePosition.z);
            }

            newCloud.transform.position = changePosition;

            BoxCollider hihi2 = newCloud.GetComponent<BoxCollider>();

            //Debug.Log("collider center : " + hihi2.center);

            //newCloud.gameObject.SetActive(true);

            //Debug.Log("change Position : " + changePosition);

            //Debug.Log("current Position : " + newCloud.transform.position);

            //Debug.Log("change Position : " + changePosition);

            //newCloud.transform.position = new Vector3(-60.4f, 81f, -88.1f);

            float cloudSize = Random.Range(0.2f, 0.2f);
            newCloud.transform.localScale = new Vector3(cloudSize, cloudSize, cloudSize);

            timer = 0;

            //if(newCloud.transform.position.z == destroyLocation)
            //{
                //Debug.Log("destroy cloud!!");
                //Debug.Log(newCloud.transform.position.z);
                Destroy(newCloud, destoryTime);
            //}
        }
    }
}
