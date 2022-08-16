using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;
    
    private void Awake() {
       Destroy(gameObject, life);
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "cloud_1(Clone)" || other.gameObject.name == "cloud_2(Clone)" || other.gameObject.name == "clouds(Clone)")
        {
            //Debug.Log("collision with cloud");
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Enemy(Clone)")
        {
            //Debug.Log("attack");
            SoundManager.instance.PlaySfx("Damage");
            if (Score.enemyDie == 0)
            {
                Debug.Log("collision with Enemy");

                Score.score += 3;
                Score.enemyDie = 2;
                Destroy(other.gameObject);
                MakeEnemy.isDie = true;
            }
            else
            {
                Debug.Log("collision with Enemy");
                Score.enemyDie--;
                Debug.Log(Score.enemyDie);
            }

            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
