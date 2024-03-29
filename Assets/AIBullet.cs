using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{

    public float AIlife = 3;
    //public static bool cameraAttacked = false;
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
            SoundManager.instance.PlaySfx("Damage");
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
                //cameraAttacked = true;
            }

            //Debug.Log("collisionssssss");
            this.gameObject.SetActive(false);
            Destroy(gameObject);
            //cameraAttacked = false;
        }
        else if (other.gameObject.name == "cloud_1(Clone)" || other.gameObject.name == "cloud_2(Clone)")
        {
            Destroy(gameObject);
        }

    }
}
