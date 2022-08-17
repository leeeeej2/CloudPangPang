using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSky : MonoBehaviour
{
    public Material blueSky;
    public Material orangeSky;
    public Material pinkSky;
    public Material darkSky;
    public Material nightSky;

    Material[] mySky = new Material[5];

    GameObject cam;

    public float timer = 0;
    public float timeDiff = 30f;

    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        mySky[0] = blueSky;
        mySky[1] = orangeSky;
        mySky[2] = pinkSky;
        mySky[3] = nightSky;
        mySky[4] = darkSky;
        
        if(MoveScene.curSky != null)
        {
            Destroy(cam.GetComponent<Skybox>());
            cam.AddComponent<Skybox>().material = MoveScene.curSky;
            
            if(mySky[0] == MoveScene.curSky)
            {
                count = 0;
            }
            else if(mySky[1] == MoveScene.curSky)
            {
                count = 1;
            }
            else if(mySky[2] == MoveScene.curSky)
            {
                count = 2;
            }
            else if(mySky[3] == MoveScene.curSky)
            {
                count = 3;
            }
            else
            {
                count = 4;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeDiff)
        {
            if(cam.GetComponent<Skybox>() != null)
            {
                Destroy(cam.GetComponent<Skybox>());
            }

            cam.AddComponent<Skybox>().material = mySky[count];
            
            count++;

            if(count == 4)
            {
                count = 0;
            }

            timer = 0;
        }
    }
}
