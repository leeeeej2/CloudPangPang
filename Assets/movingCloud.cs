using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * Time.deltaTime * speed;
    }
}
