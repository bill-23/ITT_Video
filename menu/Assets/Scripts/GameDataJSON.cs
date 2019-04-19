/** Class that creates a game data packet including both players types, emails and the game type **/

using System;

public class GameData
{
    public string playerOneType;
    public string playerTwoType;
    public string playerOneEmail;
    public string playerTwoEmail;
    public string playerOneEmoji;
    public string playerTwoEmoji;
    public string gameType;
    public float aiDiff;

    public GameData() { }

    public GameData(string playerOneType, string playerTwoType, string playerOneEmail, 
            string playerTwoEmail, string playerOneEmoji, string playerTwoEmoji, string gameType, float aiDiff) {
        this.playerOneType = playerOneType;
        this.playerTwoType = playerTwoType;
        this.playerOneEmail = playerOneEmail;
        this.playerTwoEmail = playerTwoEmail;
        this.playerOneEmoji = playerOneEmoji;
        this.playerTwoEmoji = playerTwoEmoji;
        this.gameType = gameType;
        this.aiDiff = aiDiff;
    }
}
