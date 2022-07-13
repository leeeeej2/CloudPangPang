using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int bestScore;
    // Start is called before the first frame update

    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Start()
    {
        //bestScore = PlayerPrefs.GetInt("BestScore", 0);
        Debug.Log("best score is " + bestScore);
    }

    // Update is called once per frame

    void Update()
    {
        PlayerPrefs.SetFloat("CurrentScore", Score.score);

        if (bestScore < Score.score)
        {
            bestScore = Score.score;

            PlayerPrefs.SetInt("BestScore", bestScore);
            Debug.Log("update score");
        }

        //GameObject.Find("bestScore").GetComponent<Text>().text = bestScore.ToString();
    }

    void ScoreSet(int currScore)
    {
        PlayerPrefs.SetFloat("CurrentScore", currScore);

        if(bestScore < currScore)
        {
            bestScore = currScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
