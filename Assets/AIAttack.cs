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
    private int preEnemyDie;
    private Animator animator;
    //bool playing = false;
    //private float playTime = 0.8f;

    private void Awake() {
        player = GameObject.Find("aircraft-A-A").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("IsAttacked", false);
    }

    private void Start() {
        preEnemyDie = Score.enemyDie;
    }

    private void Update() {

        if(preEnemyDie > Score.enemyDie)
        {
            animator.SetBool("IsAttacked", true);
           //playAnim.Play("EnemyAttacked");
        }
        else
        {
            animator.SetBool("IsAttacked", false);
        }

        if(!animator.GetBool("IsAttacked"))
        {
            AttackPlayer();
        }

        preEnemyDie = Score.enemyDie;
    }
/*
    public void playingAnim()
    {
        playTime = 0.8f;
        StopCoroutine("playAnimation");
        StartCoroutine("playAnimation");
    }

    private IEnumerator playAnimation()
    {
        while(playTime > 0.0f)
        {
            if(!playing)
            {
                playAnim.Play("EnemyAttacked");
                playing = true;
            }

            playTime -= Time.deltaTime;
            yield return null;
        }
        //playAnim.Play("EnemyStand");
        playing = false;
    }
    */
    private void AttackPlayer()
    {
        //playAnim.Play("EnemyStand");

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
