using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour
{
    public Text proctorGameCodeText;

    public ProctorToggleChecker proctorToggleChecker;
    public EmojiChecker emojiChecker;
    public UpdateScreens updateScreens;

    private bool aiPlayers;

    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ittseniordesign.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Update()
    {
        if (proctorToggleChecker.AreAiTogglesOn())
        {
            updateScreens.TurnOffAiSlider(false);
            aiPlayers = false;

        }
        else
        {
            updateScreens.TurnOffAiSlider(true);
            aiPlayers = true;
        }

    }

    //Create the game in the database
    public void setupGame()
    {
        List<string> list = proctorToggleChecker.checkSetupToggles();

        GameData gameData = new GameData(list[0], list[1], "email", "email", emojiChecker.getPlayerOneEmoji(), emojiChecker.getPlayerTwoEmoji(), list[2], 
            (aiPlayers ? proctorToggleChecker.getAiSlider() : -1) ) ;

        string gameCodeText = makeGameCode().ToString();

        //Get the root reference location of the database
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        //Turn the GameDataJSON class variables into a json file
        string json = JsonUtility.ToJson(gameData);
        //Create a new game under Games -> gameCode -> JSON that was just made
        reference.Child("Games").Child(gameCodeText).SetRawJsonValueAsync(json);

        proctorGameCodeText.text = "New game code: " + gameCodeText;
    }

    //Creates the random game code to be used
    public int makeGameCode()
    {
        //Make new random
        System.Random randomNumber = new System.Random();
        //Make a random game code with number from 1 -> 5000
        int newGameCode = randomNumber.Next(1, 5000);
        //TODO Check in database to make sure code isnt used yet
        return newGameCode;
    }

}
