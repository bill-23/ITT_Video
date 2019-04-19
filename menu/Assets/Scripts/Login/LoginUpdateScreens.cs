using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUpdateScreens : MonoBehaviour
{
    //Game code text box and prompt text GameObjects
    public GameObject gameCodeInputField;
    public GameObject gameCodeText;


    //Function to show or hide the game code textbox on the login screen
    public void switchLoginType(string whatType)
    {
        //If its a participant, show the game code entry box
        if (whatType == "participant")
        {
            //Show the input field
            gameCodeInputField.SetActive(true);
            gameCodeText.SetActive(true);
        }
        //Otherwise its a proctor, don't show the entry box
        else
        {
            //hide the input field
            gameCodeInputField.SetActive(false);
            gameCodeText.SetActive(false);
        }

    }
}
