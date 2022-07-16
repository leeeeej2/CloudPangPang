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
    public float destoryTime = 10.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        randomSpeed = 4;
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

        //if (mainCenter.z > sunCenter.z)
        if(gameObject.transform.position.z < (mainObject.transform.position.z - 2.5 * mainWidth))
        {
            Destroy(gameObject);
        }
    }
}
