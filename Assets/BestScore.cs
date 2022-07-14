using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int bestScore;
    public string bestName;

    public static int[] rankingScore = new int[5];
    public static string[] rankingDate = new string[5];

    public static string currTime;

    // Start is called before the first frame update
    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestName = PlayerPrefs.GetString("BestDate", System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
    }

    void Start()
    {
        //bestScore = PlayerPrefs.GetInt("BestScore", 0);
        Debug.Log("best score is " + bestScore);
        currTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
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
    }

    public static void ScoreSet(int currScore)
    {
        PlayerPrefs.SetInt("CurrentScore", currScore);
        PlayerPrefs.SetString("CurrentName", System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));

        int tmpScore = 0;
        string tmpDate = "";

        for (int i = 0; i < 5; i++)
        {   
            rankingScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            rankingDate[i] = PlayerPrefs.GetString(i + "BestDate");

            while (rankingScore[i] < currScore)
            {
                tmpScore = rankingScore[i];
                tmpDate = rankingDate[i];

                rankingDate[i] = currTime;
                rankingScore[i] = currScore;

                PlayerPrefs.SetInt(i + "BestScore", currScore);
                PlayerPrefs.SetString(i.ToString() + "BestDate", currTime);

                currScore = tmpScore;
                currTime = tmpDate;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", rankingScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestDate", rankingDate[i]);

            //Debug.Log(i + " score is : " + rankingScore[i] + "DATE is : " + rankingDate[i]);
        }
    }
}
