using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCloud : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "aircraft-A-A")
        {
            Debug.Log("collision");
            this.gameObject.SetActive(false);
            //Destroy(this);
        }

        //Debug.Log("hihi");
        //Destroy(other);
    }
}
