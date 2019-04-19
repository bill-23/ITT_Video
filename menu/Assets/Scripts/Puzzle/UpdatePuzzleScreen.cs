using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UpdatePuzzleScreen : MonoBehaviour
{
    //Text views
    public Text playerNumberText;
    public Text whosTurnText;
    public Text suggestedMoveText;
    public Text ratingText;

    //Video sections
    public VideoPlayer playerOneVideoPlayer;
    public VideoPlayer playerTwoVideoPlayer;

    //Emoji
    private string playerOneEmoji;
    private string playerTwoEmoji;

    private void Start()
    {
        playerOneVideoPlayer.Prepare();
        playerTwoVideoPlayer.Prepare();
    }

    public void setEmoji(string playerOne, string playerTwo)
    {
        playerOneEmoji = playerOne;
        playerTwoEmoji = playerTwo;
        
        playerOneVideoPlayer.url = "Assets/Animations/" + playerOne + "_Positive.mp4";
        playerTwoVideoPlayer.url = "Assets/Animations/" + playerTwo + "_Positive.mp4";
    }

    //Method to set the video player according to the satisfaction
    public void setPlayerOneVideo(string satisfaction)
    {
        if (satisfaction == "positive")
        {
            playerOneVideoPlayer.url = "Assets/Animations/" + playerOneEmoji + "_Positive.mp4";
        }
        else
        {
            playerOneVideoPlayer.url = "Assets/Animations/" + playerOneEmoji + "_Negative.mp4";
        }
    }

    //Method to set the video player according to the satisfaction
    public void setPlayerTwoVideo(string satisfaction)
    {
        if (satisfaction == "positive")
        {
            playerTwoVideoPlayer.url = "Assets/Animations/" + playerTwoEmoji + "_Positive.mp4";
        }
        else
        {
            playerTwoVideoPlayer.url = "Assets/Animations/" + playerTwoEmoji + "_Negative.mp4";
        }
    }

    //Method to update the participants screen, tells them whos turnr it is, the next players suggested move, and the satisfaction
    public void updatePromptTextOnScreen(int count, int playerNumber)
    {
        if (playerNumber == 1)
        {
            playerNumberText.text = "You are player one";
        }
        else
        {
            playerNumberText.text = "You are player two";
        }

        Debug.Log("Changing text");

        //other player
        if (playerNumber == 1 && count % 2 != 0)
        {
            whosTurnText.text = "Player two's turn";
        }
        else

        if (playerNumber == 1 && count % 2 == 0)
        {
            whosTurnText.text = "Your turn";
            suggestedMoveText.text = "Player two's suggested move:";
            ratingText.text = "Player two's rating:";
        }

        //other player
        if (playerNumber == 2 && count % 2 == 0)
        {
            whosTurnText.text = "Player one's turn";
        }
        else

        if (playerNumber == 2 && count % 2 != 0)
        {
            whosTurnText.text = "Your turn";
            suggestedMoveText.text = "Player ones's suggested move:";
            ratingText.text = "Player ones's rating:";
        }

    }

}
