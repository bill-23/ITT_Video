using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeButtons : MonoBehaviour
{

    //The satisfaction buttons
    public Button goodButton;
    public Button poorButton;

    //Will be used to trigger new game move
    public Button doneButton;

    //The suggested move buttons
    public Button oneButton;
    public Button twoButton;
    public Button threeButton;
    public Button fourButton;
    public Button fiveButton;
    public Button sixButton;
    public Button sevenButton;
    public Button eightButton;
    public Button nineButton;

    //The exit button
    public Button exitButton;

    //The block the user selected
    private int suggestedMove;

    //The users satisfaction
    private string satisfaction;

    //Create a list of the suggested moves buttons so we can index them
    private List<Button> buttonList = new List<Button>();

    //Create a list that has the button names in it so we can match the text to it, one -> nine
    private List<string> buttonIndexList = new List<string>();

    //Create a list for the satisfaction buttons
    private List<Button> satisfactionButtonList = new List<Button>();

    //Create a list for the satisfaction values, true/false
    private List<string> satisfactionIndexList = new List<string>();

    private void Start()
    {
        createSATLists();
        createSMButtonList();
    }

    //Method to make a list of the two satisfaction buttons and an index list so we can find a specific button later
    private void createSATLists()
    {
        satisfactionButtonList.Add(goodButton);
        satisfactionButtonList.Add(poorButton);

        satisfactionIndexList.Add("good");
        satisfactionIndexList.Add("poor");
    }

    //Method to make a list of the suggested move buttons and an index list so we can find a specific button later
    private void createSMButtonList()
    {
        buttonList.Add(oneButton);
        buttonList.Add(twoButton);
        buttonList.Add(threeButton);
        buttonList.Add(fourButton);
        buttonList.Add(fiveButton);
        buttonList.Add(sixButton);
        buttonList.Add(sevenButton);
        buttonList.Add(eightButton);
        buttonList.Add(nineButton);

        buttonIndexList.Add("1");
        buttonIndexList.Add("2");
        buttonIndexList.Add("3");
        buttonIndexList.Add("4");
        buttonIndexList.Add("5");
        buttonIndexList.Add("6");
        buttonIndexList.Add("7");
        buttonIndexList.Add("8");
        buttonIndexList.Add("9");
    }

    //Method to highlight the button that the other person selected during their move
    public void changeButton(string suggestedMove, string satisfaction)
    {
        //The index of the suggestion
        int indexSuggested = buttonIndexList.IndexOf(suggestedMove);

        //The index of the satisfaction
        int indexSatisfaction = satisfactionIndexList.IndexOf(satisfaction);

        //Change the color of the coorisponding suggested move button
        var colors = buttonList[indexSuggested].colors;
        colors.normalColor = Color.yellow;
        buttonList[indexSuggested].colors = colors;

        //Change the color of the coresponding satisfaction button
        var colors2 = satisfactionButtonList[indexSatisfaction].colors;
        colors2.normalColor = Color.yellow;
        satisfactionButtonList[indexSatisfaction].colors = colors2;

    }

    //Method to clear button color from previous suggestion
    public void clearButtonColor()
    {
        //Clear all of the suggestion buttons
        foreach (Button button in buttonList)
        {
            var colors = button.colors;
            colors.normalColor = Color.white;
            button.colors = colors;
        }

        //Clear all of the satisfaction buttons
        foreach (Button button in satisfactionButtonList)
        {
            var colors = button.colors;
            colors.normalColor = Color.white;
            button.colors = colors;
        }
    }

    public void exitGame()
    {
        SceneManager.LoadSceneAsync("LoginScene");
    }

    public void setSuggestedMove(int suggestedMove)
    {
        this.suggestedMove = suggestedMove;
    }

    public int getSuggestedMove()
    {
        return suggestedMove;
    }

    public void setSatisfaction(string satisfaction)
    {
        this.satisfaction = satisfaction;
    }

    public string getSatisfaction()
    {
        return satisfaction;
    }

}
