using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjuster : MonoBehaviour {
    public Light myLight;
    //Lever_Trigger Lever;
    
    //Intensity
    public bool changeIntensity = true;
    public float MaxIntensity = 10.0f;
    public bool RepeatIntensity = false;

    //Range
    public bool changeRange = false;
    public float maxRange = 10.0f;
    public bool RepeatRange = false;

    //Color 
    public bool change_colors;
    public Color startColor = Color.green;
    public Color endColor = Color.red;
    public bool RepeatColor = false;

    //Start time
    public float start_time; //We can add some random time here, or leave it for the testers to change. 

	// Use this for initialization
	void Start () {
        //When the game starts up, we want the script to catch our controller
        //Lever.anim = GetComponent<Animator>();
        myLight = GetComponent<Light>();
        start_time = Time.time;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            myLight.color = Color.green;
        }

        if (changeIntensity) {
            myLight.intensity = 5;
        }
        //If lever reaches z=158, then light turns red
        if (Input.GetKeyDown(KeyCode.Space)){

            myLight.color = Color.red;
        }
       

	}
}
