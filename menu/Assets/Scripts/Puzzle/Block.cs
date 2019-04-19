﻿
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Block : MonoBehaviour
{

    //SerialPort sp;
    public event System.Action<Block> OnBlockPressed;
    public Vector2Int coord;


    private void Start()
    {
        //sp = new SerialPort("COM7", 115200, Parity.None, 8, StopBits.One);

        //sp.Open();

        //if (sp.IsOpen)
        //    Debug.Log("Connected");
        //else
        //    Debug.Log("Not Connected");
    }

    public void Init(Vector2Int startingCoord, Texture2D image)
    {
        coord = startingCoord;

        GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Texture");
        GetComponent<MeshRenderer>().material.mainTexture = image;
    }

    void OnMouseDown()
    {
             
        OnBlockPressed(this);
        
    }

    void OnTriggerEnter(Collider col)
    {
        //if (!sp.IsOpen)
        //{
        //    Debug.Log("I was closed, now I'm open");
        //    sp.Open();
        //}
        Debug.Log(col.gameObject.name);
        //sp.Write(col.gameObject.name);

        OnBlockPressed(this);
        //sp.Close();
    }

}

