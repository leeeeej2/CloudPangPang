using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    public Image[] gunButton;
    public static int pressed = 1;
    public static bool IsPressed = false;

    public Sprite Unpressed;
    public Sprite Pressed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("firebutton"))
        {
            Debug.Log("Pressed");
            IsPressed = true;
            gunButton[0].sprite = Pressed;
        }
        else 
        {
            Debug.Log("Unpressed");
            IsPressed = false;
            gunButton[0].sprite = Unpressed;
        }
    }
}
