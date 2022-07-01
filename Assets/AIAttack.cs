using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Transform player;
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public Transform Enemy;
    public GameObject AIbullet;
    public Transform shootPoint;

    public float AIBulletSpeed = 10;

    private void Awake() {
        player = GameObject.Find("aircraft-A-A").transform;

    }

    private void Update() {
        AttackPlayer();

    }

    private void AttackPlayer()
    {
        transform.LookAt(player);
        transform.Rotate(0, 40, 0);

        if(!alreadyAttacked)
        {
            //Attack
            GameObject currentBullet = Instantiate(AIbullet, shootPoint.position, shootPoint.rotation);
            Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
            rig.AddForce(transform.forward * AIBulletSpeed, ForceMode.VelocityChange);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
