using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PuzzleDatabaseHandler : MonoBehaviour
{
    public UpdatePuzzleScreen updatePuzzleScreen;
    public ChangeButtons changebuttons;
    public Puzzle puzzle;

    //The local game count
    private int localCount;

    //Read this from the PlayerHandler
    private string gameCode;
    private string email;
    private int playerNumber;

    //Update these every database call
    private string satisfaction;
    private string suggestedMove;
    private int databaseCount;
    private int blockToMove;

    private int blockUserMoved;


    // Start is called before the first frame update
    void Start()
    {
        //We have to find the PlayerHandler script that we never killed
        PlayerHandler playerHandler = GameObject.FindObjectOfType<PlayerHandler>();

        //Set the variable accordingly
        gameCode = playerHandler.getGameCode();
        email = playerHandler.getEmail();
        playerNumber = playerHandler.getPlayerNumber();

        if (playerNumber == 1)
        {
            localCount = 0;
        }
        else
        {
            localCount = 1;
        }

        updatePuzzleScreen.setEmoji(playerHandler.getPlayerOneEmoji(), playerHandler.getPlayerTwoEmoji());

        Debug.Log("From Puzzle Database Handler: " + gameCode + "," + email + "," + playerNumber);

        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ittseniordesign.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        //Start listening for changes to the database
        StartListener(gameCode);
    }

    //Listens to data that has changed in the Games -> Moves section of the database
    public void StartListener(string gameCode)
    {
        Debug.Log("Listener started");
        updatePuzzleScreen.updatePromptTextOnScreen(databaseCount, playerNumber);
        //Get the location of Games -> Moves (because this is where we want to see changes)
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Games").Child(gameCode).Child("Moves");
        //If something changes here then run the HandleChildChanged method
        reference.ChildAdded += HandleChildChanged;
    }

    //Handles the result if something changed in the Games -> GameCode -> Moves section of the database
    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        Debug.Log("A value has changed");

        //Data comes in as a key, value pair <string, object>
        Dictionary<string, object> update = (Dictionary<string, object>)args.Snapshot.Value;
        
        //Get the value of the object with the key of "satisfaction"
        object sat = (object)update["satisfaction"];
        
        //Get the value of the object with the key of "suggestedMove"
        object sug = (object)update["suggestedMove"];
        
        //Update the proper count
        object cnt = (object)update["count"];       

        //Get the block to move
        object blk = (object)update["blockToMove"];

        satisfaction = sat.ToString();
        suggestedMove = sug.ToString();
        databaseCount = int.Parse(cnt.ToString());
        blockToMove = int.Parse(blk.ToString());


        updatePuzzleScreen.updatePromptTextOnScreen(databaseCount, playerNumber);

        if (playerNumber == 1 && isEven(databaseCount))
        {
            //move the block
            puzzle.makeOtherPlayersMove(blockToMove);
            //change the colors of the buttons
            changebuttons.changeButton(suggestedMove, satisfaction);
            //Update the video player
            updatePuzzleScreen.setPlayerOneVideo(satisfaction);
            updatePuzzleScreen.setPlayerTwoVideo(satisfaction);
        }
        else
        if (playerNumber == 2 && !isEven(databaseCount))
        {
            //move the block
            puzzle.makeOtherPlayersMove(blockToMove);
            //change the colors of the buttons
            changebuttons.changeButton(suggestedMove, satisfaction);
            //Update the video player
            updatePuzzleScreen.setPlayerOneVideo(satisfaction);
            updatePuzzleScreen.setPlayerTwoVideo(satisfaction);
        }
    }

    private bool isEven(int count)
    {
        bool isEven;

        if (count % 2 == 0)
        {
            isEven = true;
        }
        else
        {
            isEven = false;
        }

        return isEven;
    }

    public void SetBlockUserMoved(int blockUserMoved)
    {
        this.blockUserMoved = blockUserMoved;
        changebuttons.clearButtonColor();
    }

    //Method to make the move 
    public void makeMove()
    {
        localCount++;

        Debug.Log("Game code for move: " + gameCode);

        //Make a JSON for this game move
        GameMoveJSON moveJson = new GameMoveJSON(email, blockUserMoved, changebuttons.getSuggestedMove().ToString(), changebuttons.getSatisfaction(), localCount);

        //Get the root reference location of the database
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        //Turn the incoming GameMoveJSON into a JSON file
        string json = JsonUtility.ToJson(moveJson);

        //Add the move to the proper move location in database
        reference.Child("Games").Child(gameCode).Child("Moves").Child("move" + localCount).SetRawJsonValueAsync(json);
    }

}
