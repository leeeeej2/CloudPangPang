using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int enemyDie = 2;
    public static int feverScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            GameObject.Find("bestbest").GetComponent<Text>().text = BestScore.bestScore.ToString();
            GameObject.Find("curcur").GetComponent<Text>().text = score.ToString();
            GameObject.Find("firstScore").GetComponent<Text>().text = BestScore.rankingScore[0].ToString();
            GameObject.Find("secondScore").GetComponent<Text>().text = BestScore.rankingScore[1].ToString();
        }
        else if(SceneManager.GetActiveScene().name == "FeverTime") 
        {
            GameObject.Find("FeverScore").GetComponent<Text>().text = feverScore.ToString();
        }
        else
        {
            GameObject.Find("scores").GetComponent<Text>().text = score.ToString();
        }
    }
}
