/* This Class makes a connection with the database and checks if there is an opening at the specific game code.
 * If a spot is open then it adds the participant to the database and logs the player number in the PlayerHandler class */

using Firebase;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;


public class LoginDatabaseHandler : MonoBehaviour
{
    //Non-Destroyable class to hold our game code and player number
    public PlayerHandler playerHandler;

    //The task type, so we can send them to the right task
    private string taskType;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ittseniordesign.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //Method to see if the game is open, if it is then assign the player a number and put them in the database
    public void CheckIfGameIsOpen(string email, string gameCode)
    {
        Debug.Log("reading players from database with gamecode: " + gameCode);

        //Default reference of where were going to look
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        //This will get the data once at the "Games" -> "GameCode" section
        FirebaseDatabase.DefaultInstance
        .GetReference("Games").Child(gameCode)
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Error occured");
            }
            else if (task.IsCompleted)
            {
                //What we read in from the database. Comes in as a object with key we defined
                DataSnapshot snapshot = task.Result;
                Dictionary<string, object> update = (Dictionary<string, object>)snapshot.Value;
                
                //We need the emails
                object emailOne = (object)update["playerOneEmail"];
                object emailTwo = (object)update["playerTwoEmail"];

                //We also need the game type so we can send them to the right task
                object taskRoom = (object)update["gameType"];
                //Set the value
                taskType = taskRoom.ToString();
                Debug.Log("Task type: " + taskType);

                //We need the Emojis for each player
                object pOneEmoji = (object)update["playerOneEmoji"];
                object pTwoEmoji = (object)update["playerTwoEmoji"];

                string playerOneEmoji = pOneEmoji.ToString();
                string playerTwoEmoji = pTwoEmoji.ToString();

                //The players to check against
                string playerOne = emailOne.ToString();
                string playerTwo = emailTwo.ToString();

                Debug.Log("Player one email: " + playerOne + " Player two email: " + playerTwo);

                //Blank spaces in the game setup have value of "email", so check each and assign to first available
                if (playerOne == "email")
                {
                    Debug.Log("Setting player one");
                    isOpen = true;
                    reference.Child("Games").Child(gameCode).Child("playerOneEmail").SetValueAsync(email);
                    SetValues(email, gameCode, 1, playerOneEmoji, playerTwoEmoji);
                }
                else
                if (playerTwo == "email")
                {
                    Debug.Log("Setting player two");
                    isOpen = true;
                    reference.Child("Games").Child(gameCode).Child("playerTwoEmail").SetValueAsync(email);
                    SetValues(email, gameCode, 2, playerOneEmoji, playerTwoEmoji);    
                }
                else
                {
                    Debug.Log("Game is not open!");
                    isOpen = false;
                }

            }

        });

    }

    //Method to set values in our PlayerHandler class
    private void SetValues(string email, string gameCode, int playerNumber, string playerOneEmoji, string playerTwoEmoji)
    {
        playerHandler.setEmail(email);
        playerHandler.setGameCode(gameCode);
        playerHandler.setPlayerNumber(playerNumber);
        playerHandler.setPlayerOneEmoji(playerOneEmoji);
        playerHandler.setPlayerTwoEmoji(playerTwoEmoji);
    }

    //Getter for the task type
    public string getTaskType()
    {
        return taskType;
    }

    //Getter for game status
    public bool getGameStatus()
    {
        Debug.Log("Game is " + (isOpen ? "open" : "closed"));
        return isOpen;
    }
}

