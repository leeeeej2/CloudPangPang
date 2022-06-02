using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float randomSpeed;
    bool once = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSpeed = Random.Range(0, 2);
        if(once)
        {
            speed += randomSpeed;
            once = false;
        }
        transform.position -= Vector3.forward * Time.deltaTime * speed;
    }
}
