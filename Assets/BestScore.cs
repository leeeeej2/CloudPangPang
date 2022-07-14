using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int bestScore;
    public string bestName;

    public static int[] rankingScore = new int[5];
    public static string[] rankingName = new string[5];

    // Start is called before the first frame update
    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestName = PlayerPrefs.GetString("BestName", "hagyeong");
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

        //GameObject.Find("bestbest").GetComponent<Text>().text = bestScore.ToString();
    }

    public static void ScoreSet(int currScore, string currName)
    {
        PlayerPrefs.SetInt("CurrentScore", currScore);
        PlayerPrefs.SetString("CurrentName", currName);

        int tmpScore = 0;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {   
            rankingScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            rankingName[i] = PlayerPrefs.GetString(i + "BestName");

            while (rankingScore[i] < currScore)
            {
                tmpScore = rankingScore[i];
                tmpName = rankingName[i];

                rankingName[i] = currName;
                rankingScore[i] = currScore;

                PlayerPrefs.SetInt(i + "BestScore", currScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currName);

                currScore = tmpScore;
                currName = tmpName;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", rankingScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", currName);

            //Debug.Log("best score : " + rankingScore[i] + "index is : " + i);
        }
    }
}
