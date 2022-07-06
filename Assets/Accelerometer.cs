using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    float dirX;
    float moveSpeed = 25f;

    /////////for pc control
    float moveX = 0f;
    float moveY = 0f;
    float moveZ = 0f;
    /////////
    
    private void Start() {
       rigid = GetComponent<Rigidbody>();

        moveX = transform.position.x;
        moveY = transform.position.y;
        moveZ = transform.position.z;
    }

   private void Update() {
      
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), transform.position.y, transform.position.z);

        /////////for pc control
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("left");
            moveX--;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }

        if (Input.GetKey(KeyCode.D))
        {
             Debug.Log("right");
             moveX++;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("up");
            moveY++;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("down");
            moveY--;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }
        /////////
    }

    private void FixedUpdate() {
       rigid.velocity = new Vector3(dirX, 0, 0);
   }
}
