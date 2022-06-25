using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Transform player;
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField]
    GameObject bullet;

    private void Awake() {
        player = GameObject.Find("aircraft-A-A").transform;

    }

    private void Update() {
        AttackPlayer();

    }

    private void AttackPlayer()
    {
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack
            Instantiate(bullet, transform.position, Quaternion.identity);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
