using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    //exits the game when the "Exit Game" button is pressed
    public void ExitGame()
    { 
        Application.Quit();
    }
}
