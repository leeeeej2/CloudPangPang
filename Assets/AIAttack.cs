using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Transform player;
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public Transform AIbulletSpawnPoint;
    public GameObject AIbulletPrefab;
    public float AIBulletSpeed = 10;

    private void Awake() {
        player = GameObject.Find("aircraft-A-A").transform;

    }

    private void Update() {
        AttackPlayer();

    }

    private void AttackPlayer()
    {
        //transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack
            var aibullet = Instantiate(AIbulletPrefab, AIbulletSpawnPoint.position, AIbulletSpawnPoint.rotation);
            aibullet.GetComponent<Rigidbody>().velocity = AIbulletSpawnPoint.forward * AIBulletSpeed;
           
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
