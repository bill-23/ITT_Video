using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiChecker : MonoBehaviour
{
    private bool playerOneChosen = false;
    private bool playerTwoChosen = false;

    public Button oneButton;
    public Button twoButton;
    public Button threeButton;
    public Button fourButton;
    public Button fiveButton;
    public Button sixButton;
    public Button sevenButton;
    public Button eightButton;
    public Button nineButton;
    public Button tenButton;
    public Button elevenButton;
    public Button twelveButton;
    public Button thirteenButton;
    public Button fourteenButton;
    public Button fifteenButton;
    public Button sixteenButton;
    public Button seventeenButton;

    private string playerOneEmoji;
    private string playerTwoEmoji;

    public UpdateScreens updateScreens;

    public void setEmoji(string emoji)
    {
        if (!playerOneChosen)
        {
            playerOneEmoji = emoji;
            updateScreens.ChangeEmojiText("two");
            playerOneChosen = true;
        }
        else

        if (!playerTwoChosen)
        {
            playerTwoEmoji = emoji;
            updateScreens.ChangeEmojiText("done");
            playerTwoChosen = true;
        }
    }

    public string getPlayerOneEmoji()
    {
        return playerOneEmoji;
    }

    public string getPlayerTwoEmoji()
    {
        return playerTwoEmoji;
    }
}
