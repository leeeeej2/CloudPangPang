using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    float dirX;
    float moveSpeed = 20f;

    /////////for pc control
    float moveX = 0f;
    float moveY = 0f;
    float moveZ = 0f;

    public float maxCameraX = 1f;
    public float minCameraX = 0;
    public float maxCameraY = 1f;
    public float minCameraY = 0;
    /////////

    private void Start() {
        rigid = GetComponent<Rigidbody>();

        moveX = transform.position.x;
        moveY = transform.position.y;
        moveZ = transform.position.z;
    }

    private void Update() {
        dirX = Input.acceleration.x * moveSpeed;
        
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), transform.position.y, transform.position.z);        
        
        /////////for pc control
        if (Input.GetKey(KeyCode.A) && DoNotOut.leftMove)
        {
             moveX--;
             transform.position = new Vector3(moveX, moveY, moveZ);          
        }

        if (Input.GetKey(KeyCode.D) && DoNotOut.rightMove)
        {
             moveX++;
             transform.position = new Vector3(moveX, moveY, moveZ);           
        }

        if (Input.GetKey(KeyCode.W) && DoNotOut.upMove)
        {
            moveY++;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }

        if (Input.GetKey(KeyCode.S) && DoNotOut.downMove)
        {
            moveY--;
            transform.position = new Vector3(moveX, moveY, moveZ);
        }
        /////////  
           
    }

private void FixedUpdate() {
       
        if(!DoNotOut.rightMove)
        {
            rigid.velocity = new Vector3(-1, 0, 0);
        }
        else if(!DoNotOut.leftMove)
        {
            rigid.velocity = new Vector3(1, 0, 0);
        }
        else
        {
            rigid.velocity = new Vector3(dirX, 0, 0);
        }
    }
}
