using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static bool addOnce = true;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");

        //reset all data to start new game
        Score.score = 0;
        Score.enemyDie = 2;
        Score.feverScore = 0;
        EatCloud.whiteCount = 0;
        EatCloud.yellowCount = 0;
        EatCloud.pinkCount = 0;
        EatCloud.blueCount = 0;

        EatCloud.totalCount = 0;
        EatCloud.ammoCount = 3;

        EatCloud.perCloud = 2;

        EatCloud.stopPink = false;
        EatCloud.stopBlue = false;
        EatCloud.stopYellow = false;

        MakeEnemy.isDie = false;

        HealthManager.lifeSystem = 3;
        HealthManager.unlimitedMood = false;
        //
}

    public void QuitGame()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); 
        #endif
    }

    public static void GameOver()
    {
        BestScore.bestScore = PlayerPrefs.GetInt("BestScore", 0);
        //bestName = PlayerPrefs.GetString("BestName", "hagyeong");

        BestScore.ScoreSet(Score.score);
        SceneManager.LoadScene("GameOver");
    }

    public static void GoFeverTime()
    {
        SceneManager.LoadScene("FeverTime");
        addOnce = true;

        //Debug.Log("white cloud is" + EatCloud.whiteCount);
        //Debug.Log("pink cloud is" + EatCloud.pinkCount);
        //Debug.Log("yellow cloud is" + EatCloud.yellowCount);
        //Debug.Log("blue cloud is" + EatCloud.blueCount);
    }

    public static void GoBack()
    {
        SceneManager.LoadScene("SampleScene");

        if(addOnce)
        {
            //Debug.Log("Original score is" + Score.score);
            //Debug.Log("Sun score is" + Score.feverScore);

            //Debug.Log("white cloud is" + EatCloud.whiteCount);
            //Debug.Log("pink cloud is" + EatCloud.pinkCount);
            //Debug.Log("yellow cloud is" + EatCloud.yellowCount);
            //Debug.Log("blue cloud is" + EatCloud.blueCount);

            Score.score += Score.feverScore;
            addOnce = false;
        }

    }
}
