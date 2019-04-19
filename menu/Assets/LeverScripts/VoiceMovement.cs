using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class VoiceMovement : MonoBehaviour {
    //We need a keyword Recognizer to have it listen and recognize the voice
    private KeywordRecognizer keywordRecognizer;


    //We need a dictionary with one part being the string. The string is the actual word that
    //It's waiting to hear. Action is the function that it will call that's associated with the string (word)
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start() {
        //Populate the dictionary with the commands that we want. 
        actions.Add("forward", Forward);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void Forward() {

    }

}

