using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;

    private void Awake() {
       Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "cloud_1(Clone)" || other.gameObject.name == "cloud_2(Clone)")
        {
            //Debug.Log("collision with cloud");
            Destroy(gameObject);
        }
        else 
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
