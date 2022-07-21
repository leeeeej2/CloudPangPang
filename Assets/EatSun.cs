using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatSun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "aircraft-A-A")
        {
            this.gameObject.SetActive(false);
            //Debug.Log("Sun Collider");
            Score.feverScore++;
        }
    }
}
