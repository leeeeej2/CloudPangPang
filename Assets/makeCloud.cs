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

    void Start()
    {
        
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

            Debug.Log(whatType);

            if(whatType == 0)
            {
                newCloud = Instantiate(cloud);
            }
            
            if(whatType == 1)
            {
                newCloud = Instantiate(cloud2);
            }

            Vector3 mainPosition = mainObject.transform.position;
            
            newCloud.transform.position = new Vector3(Random.Range(xMin , xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            float cloudSize = Random.Range(0.2f, 0.5f);
            newCloud.transform.localScale = new Vector3(cloudSize, cloudSize, cloudSize);
            
            timer = 0;

            Destroy(newCloud, destoryTime);
        }
    }
}
