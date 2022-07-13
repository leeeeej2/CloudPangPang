using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{

    public float AIlife = 3;

    //void Update()
    //{
    //    gameObject.GetComponent<BoxCollider>().enabled = true;
    //}

    private void Awake() {
        Destroy(gameObject, AIlife);
    }
    
    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.name == "aircraft-A-A")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "cloud_1(Clone)" || other.gameObject.name == "cloud_2(Clone)" || other.gameObject.name == "clouds(Clone)")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "aircraft-A-A")
        {
            if(HealthManager.lifeSystem > 0)
            {
                HealthManager.lifeSystem--;
            }

            //Debug.Log("collisionssssss");
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "cloud_1(Clone)" || other.gameObject.name == "cloud_2(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
