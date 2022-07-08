using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cloud;
    public GameObject cloud2;
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
    GameObject newCloud;

    public static Color white;
    public static Color yellow;
    public static Color pink;
    public static Color blue;

    public Color[] myColors;
    public Color pickColor;
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
        int whatType = 0;

        if(timer > timeDiff)
        {
            //x -10 ~ 10
            //y -15 ~ 15
        
            whatType = Random.Range(0, 2);

            if(whatType == 0)
            {
                newCloud = Instantiate(cloud);
            }
            
            if(whatType == 1)
            {
                newCloud = Instantiate(cloud2);
            }

            pickColor = myColors[Random.Range(0, myColors.Length)];
            newCloud.GetComponent<MeshRenderer>().material.color = pickColor;

            Vector3 mainPosition = mainObject.transform.position;
            newCloud.transform.position = new Vector3(Random.Range(xCloudRangeMin , xCloudRangeMax), Random.Range(yCloudRangeMin, yCloudRangeMax), Random.Range(zMin, zMax));
            //newCloud.transform.position = new Vector3(-30f, 16.3f, 6.5f);
            float cloudSize = Random.Range(0.2f, 0.5f);
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
