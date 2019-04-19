using UnityEngine;
using UnityEngine.UI;

public class LoginToggleChecker : MonoBehaviour
{
    //Toggles for the Login screen
    public Toggle participantToggle;
    public Toggle proctorToggle;

    //Function to check whos playing. 
    public string checkWhosPlaying()
    {
        string whosPlaying = "";

        if (participantToggle.isOn)
        {
            whosPlaying = "participant";
        }

        if (proctorToggle.isOn)
        {
            whosPlaying = "proctor";
        }

        return whosPlaying;
    }

}
