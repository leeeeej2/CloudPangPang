using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cloud;
    public GameObject cloud2;
    public GameObject mainObject;

    public float xMax = -15f;
    public float xMin = -50f;

    public float yMax = 0;
    public float yMin = 25f;

    public float zMax = 25f;
    public float zMin = 30f;

    public float timer = 0;
    public float timeDiff = 1.5f;
    public float destoryTime = 10.0f;

    GameObject newCloud;

    Color white;
    Color yellow;
    Color pink;
    Color blue;

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
            newCloud.transform.position = new Vector3(Random.Range(xMin , xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            //newCloud.transform.position = new Vector3(-30f, 16.3f, 6.5f);
            float cloudSize = Random.Range(0.2f, 0.5f);
            newCloud.transform.localScale = new Vector3(cloudSize, cloudSize, cloudSize);


            timer = 0;

            Destroy(newCloud, destoryTime);
        }
    }
}
