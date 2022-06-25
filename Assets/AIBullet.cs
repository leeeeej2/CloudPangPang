using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{
    public float AIlife = 3;

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
}
