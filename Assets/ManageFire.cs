using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFire : MonoBehaviour
{
    public static bool IsPressed = false;
    
    public void PressButton()
    {
        IsPressed = true;
    }
}
