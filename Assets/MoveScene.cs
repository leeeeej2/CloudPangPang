using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Score.score = 0;
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
    }

    public static void GoBack()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
