using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScreens : MonoBehaviour
{
    //Game code text box and prompt text GameObjects
    public GameObject gameCodeInputField;
    public GameObject gameCodeText;

    public Text characterSelectionText;

    public GameObject aiSlider;
    public GameObject aiSliderText;

    //Function to show or hide the game code textbox on the login screen
    public void switchLoginType(bool whatType)
    {
        //If true then its a participant, show the game code entry box
        if (whatType)
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

    public void ChangeEmojiText(string player)
    {
        if (player == "done")
        {
            characterSelectionText.text = "Avatar selection completed";
        }
        else
        {
            characterSelectionText.text = "Select player " + player + "'s avatar";
        }
    }

    public void TurnOffAiSlider(bool on)
    {
        if (on)
        {
            aiSlider.SetActive(true);
            aiSliderText.SetActive(true);
        }
        else
        {
            aiSlider.SetActive(false);
            aiSliderText.SetActive(false);
        }
    }

}
