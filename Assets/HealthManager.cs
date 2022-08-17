using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts;
    public static int lifeSystem = 3;
    
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public static bool unlimitedMood = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for(int i = 0; i < lifeSystem; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!unlimitedMood)
            {
                    unlimitedMood = true;
                    Debug.Log("unlimited mood on");
            }
            else
            {
                    unlimitedMood = false;
                    Debug.Log("unlimited mood off");
            }
        }

        if(lifeSystem < 1 && unlimitedMood == false)
        {
            MoveScene.GameOver();
            lifeSystem = 3;
        }
    }
}
