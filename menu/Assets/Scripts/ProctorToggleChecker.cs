//* Class that will check all toggles *//

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProctorToggleChecker : MonoBehaviour
{

    //Toggles for the proctor screen
    public Toggle playerOneAiToggle;
    public Toggle playerOneHumanToggle;
    public Toggle playerTwoAiToggle;
    public Toggle playerTwoHumanToggle;
    public Toggle puzzleToggle;
    public Toggle leverToggle;

    public Slider aiSlider;

    //Function to check which toggles are enabled on the proctor screen
    public List<string> checkSetupToggles()
    {
        //If the playerOneHumanToggle is on then they are human
        string playerOneType = playerOneHumanToggle.isOn ? "Human": "AI";
        //If the playerTwoHumanToggle is on then they are human
        string playerTwoType = playerTwoHumanToggle.isOn ? "Human" : "AI";
        //If the puzzleToggle is on then it should be a puzzle game
        string gameType = puzzleToggle.isOn ? "Puzzle" : "Lever";

        //return each type in a list
        return new List<string> {playerOneType, playerTwoType, gameType};
    }

    public bool AreAiTogglesOn()
    {
        bool bothOn = false;

        if (!playerOneAiToggle.isOn && !playerTwoAiToggle.isOn)
        {
            bothOn = true;
        }

        return bothOn;
    }

    public float getAiSlider()
    {
        return aiSlider.value;
    }
}
