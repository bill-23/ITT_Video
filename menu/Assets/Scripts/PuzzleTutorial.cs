using Eigth_Puzzle_Problem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTutorial : MonoBehaviour
{
    public Text headerText;
    public Text subText;

    private int count = 0;

    Program program = new Program();

    public void ChangeScreens()
    {
        count++;

        switch (count)
        {
            case 0:
                headerText.text = "Welcome!";
                subText.text = "You have been chosen to complete the sliding 8 puzzle teamwork task.";
                
                break;
            case 1:
                headerText.text = "Task Overview: ";
                subText.text = "This task is split into three main components.";

                break;
            case 2:
                headerText.text = "Task Area One: ";
                subText.text = "Puzzle tiles are moved by pressing a tile adjacent to the open space.";

                break;
            case 3:
                headerText.text = "Task Area Two: ";
                subText.text = "Make a suggested move for the other participant here.";

                break;
            case 4:
                headerText.text = "Task Area Three: ";
                subText.text = "Press either the Good or Bad button to indicate your satisfaction of the previous move.";

                break;

        }
    }

}
