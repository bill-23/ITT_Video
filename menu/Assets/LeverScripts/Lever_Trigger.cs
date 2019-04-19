using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
public class Lever_Trigger : MonoBehaviour {

    public Animator anim;

    //public float animation_speed1 = Random.Range(1, 15);
    public float animation_speed;
    //We need a keyword Recognizer to have it listen and recognize the voice
    private KeywordRecognizer keywordRecognizer;
    
    //We need a dictionary with one part being the string. The string is the actual word that
    //It's waiting to hear. Action is the function that it will call that's associated with the string (word)
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start () {
        //When the game starts up, we want the script to catch our controller
        //Populate the dictionary with the commands that we want. 
        anim = GetComponent<Animator>();
        actions.Add("forward", Forward);
        actions.Add("slower", Slower);
        actions.Add("lets restart", Restart);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        //Start listening
        keywordRecognizer.Start();
        
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    //Anyone can adjust the speed
    private void Forward() {
        anim.speed = animation_speed;
        anim.Play("Lever_Animation");

    }

    //The speed is slowed down
    private void Slower(){
        anim.speed = 1;
        anim.Play("Lever_Animation");
    }
    
    //It pulls the lever back up 
    private void Restart() {
        anim.speed = 1;
        anim.Play("New State", -1, 0f);
    }
    

}
