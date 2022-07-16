using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float randomSpeed;
    bool once = true;
    public float destoryTime = 30.0f;

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
        Destroy(gameObject, destoryTime);
    }
}
