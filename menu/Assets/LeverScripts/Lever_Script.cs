using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Script : MonoBehaviour {
    public Animator anim;
    //public Light myLight;
    //Lever_Trigger Lever;
//    public float start_time; //We can add some random time here, or leave it for the testers to change. 


    //public float animation_speed1 = Random.Range(1, 15);
    public float animation_speed;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.Play("Lever_Animation");
            anim.speed = animation_speed;
           

        }
}



}
