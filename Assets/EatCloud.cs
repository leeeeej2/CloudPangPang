using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCloud : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if(other.GetType() == )
        Debug.Log(other.GetType());
        //Debug.Log("hihi");
        //Destroy(other);
    }
}
