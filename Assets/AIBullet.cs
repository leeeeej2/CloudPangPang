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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "aircraft-A-A")
        {
            Debug.Log("collisionssssss");
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
