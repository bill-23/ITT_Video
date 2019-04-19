/* This is a data class of sorts. It will not be destroyed between scenes so we can read from the database again.
 * Not the best, but hey. */

using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private string email;
    private string gameCode;
    private int playerNumber;
    private string playerOneEmoji;
    private string playerTwoEmoji;

    private void Start()
    {
        //This makes sure that it stays live throuought the lifecycle of the tasks
        DontDestroyOnLoad(this.gameObject);
    }

    public void setPlayerOneEmoji(string playerOneEmoji)
    {
        this.playerOneEmoji = playerOneEmoji;
    }

    public string getPlayerOneEmoji()
    {
        return playerOneEmoji;
    }

    public void setPlayerTwoEmoji(string playerTwoEmoji)
    {
        this.playerTwoEmoji = playerTwoEmoji;
    }

    public string getPlayerTwoEmoji()
    {
        return playerTwoEmoji;
    }

    public void setEmail(string email)
    {
        Debug.Log("Email set: " + email);
        this.email = email;
    }

    public string getEmail()
    {
        return email;
    }

    public void setGameCode(string gameCode)
    {
        Debug.Log("Game code set: " + gameCode);
        this.gameCode = gameCode;
    }

    public string getGameCode()
    {
        return gameCode;
    }

    public void setPlayerNumber(int playerNumber)
    {
        Debug.Log("Player number set: " + playerNumber);
        this.playerNumber = playerNumber;
    }

    public int getPlayerNumber()
    {
        return playerNumber;
    }

}
