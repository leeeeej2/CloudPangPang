using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour
{
    public GameObject mainObject;

    // Start is called before the first frame update
    public float speed;
    float randomSpeed;
    bool once = true;
    public float destoryTime = 30.0f;

    GameObject thsLastSun;
    public float sunDistance = 2.45f;
    
    Vector3 lastLocation;
    float timer = 0;

    bool isGone = false;

    void Start()
    {
        isGone = false;
        thsLastSun = GameObject.FindWithTag("lastSun");
        lastLocation = thsLastSun.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        randomSpeed = 15;

        if(once) 
        {
            speed += randomSpeed;
            once = false;
        }
        transform.position -= Vector3.forward * Time.deltaTime * speed;

        //if(Main.ctransform.position.)

        //float mainCenter = GetComponent.<RectTransform>().rect.width;
        float mainWidth = mainObject.GetComponent<BoxCollider>().size.z;

        //Debug.Log("main location is " + mainCenter.z);
        //sDebug.Log("sun location is  " + sunCenter.z);

        if(gameObject.transform.position.z < (mainObject.transform.position.z - 2.5 * mainWidth))
        {
            Destroy(gameObject);
        }

        if(!isGone)
        {
            thsLastSun = GameObject.FindWithTag("lastSun");
            lastLocation = thsLastSun.transform.position;

            if ((lastLocation.z - mainWidth) < mainObject.transform.position.z)
            {
                Debug.Log("sun will be die");
                isGone = true;
            }

            Score.score += Score.feverScore;
        }

        if(isGone)
        {
            timer += Time.deltaTime;

            Debug.Log(timer);

            if (timer > 2.0f)
            {
                Debug.Log("we have to go back");
                MoveScene.GoBack();
                timer = 0;
                isGone = false;
            }
        }
    }
}
