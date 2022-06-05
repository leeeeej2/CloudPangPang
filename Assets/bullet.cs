using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;

    private void Awake() {
       Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
