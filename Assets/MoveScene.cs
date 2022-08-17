using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static bool addOnce = true;
    public static bool isGamePause = false;
    public Slider volSlider;
    public static Material curSky;
    public static float soundVolumeControl = 0.5f;
    public static string currentScene;

    private void Awake()
    {
        //currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("volvol", 0.5f);
    }

    private void Update()
    {
        
    }
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

        curSky = null;
    }

    public void QuitGame()
    {
        PlayerPrefs.SetFloat("volvol", 0.5f);

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
        curSky = GameObject.Find("Main Camera").GetComponent<Skybox>().material;

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

    public static void PauseGame()
    {
        currentScene = SceneManager.GetActiveScene().name;
        curSky = GameObject.Find("Main Camera").GetComponent<Skybox>().material;
        Debug.Log("Curr Scene" + currentScene);
        Time.timeScale = 0;
        isGamePause = true;
        SceneManager.LoadScene("SettingScene");
        Debug.Log("pause");
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePause = false;
        SceneManager.LoadScene(currentScene);
        Debug.Log(currentScene);
    }

    public void SetBGMVolume(float slider)
    {
        volSlider.value = slider;
        //Debug.Log("volume is " + volSlider.value);
        soundVolumeControl = volSlider.value;
        PlayerPrefs.SetFloat("volvol", volSlider.value);
    }
}
