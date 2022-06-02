using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    float dirX;
    float moveSpeed = 20f;

    private void Start() {
       rigid = GetComponent<Rigidbody>();
   }

   private void Update() {
      
      dirX = Input.acceleration.x * moveSpeed;
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, -16f, 16f), transform.position.y, transform.position.z);
       //Vector3 tilt = Input.acceleration;

        //if(isFlat)
        //{
        //    tilt = Quaternion.Euler(90, 0, 0) * tilt;
        //}

       //rigid.AddForce(Input.acceleration);
       //Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
       
   }

   private void FixedUpdate() {
       rigid.velocity = new Vector3(dirX, 0, 0);
   }
}