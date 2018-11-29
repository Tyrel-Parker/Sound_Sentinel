﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {
    public Canvas canvas;
    public KeyCode vivePauseButton;
    public KeyCode keyboardPauseButton;// = "Escape";
    public KeyCode resumeButton;
    GameObject tempObject;
    GameObject[] tempObjectTwo;
    // Use this for initialization
    //When scene loads turn off pause menu and pause menu buttons
    void Start()
    {
        canvasOff();
        tempObjectTwo = GameObject.FindGameObjectsWithTag("Button");
        for (int x = 0; x < tempObjectTwo.Length; x++)
        {
          tempObjectTwo[x].SetActive(false);
        }
       //tempObject = GameObject.FindGameObjectWithTag("rightcontroller");
       // tempObject.SetActive(false);
    }
    public void canvasOff()
    {
        canvas = canvas.GetComponent<Canvas>();
        canvas.enabled = false;
    }
    //watch for either pause button to be pressed and open pause menu when it does
    void Update()
    {
        if (Input.GetKey(vivePauseButton) || Input.GetKey(keyboardPauseButton))
        {
            canvas.enabled = true;
           // tempObject = GameObject.FindGameObjectWithTag("shield");
           // tempObject.SetActive(false);
           // tempObject = GameObject.FindGameObjectWithTag("rightcontroller");
           // tempObject.SetActive(true);
           //GameObject.FindGameObjectWithTag("BallCreation").GetComponent<CreateBalls>().PauseCreation();
            for (int k = 0; k < tempObjectTwo.Length; k++)
            {
                tempObjectTwo[k].SetActive(true);
            }
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            for(int i=0; i<balls.Length; i++)
            {
                balls[i].GetComponent<Start_and_Stop>().PauseBall();
            }
            GameObject.FindGameObjectWithTag("Ball Creation").GetComponent<CreateBalls>().PauseCreation();
            GameObject.FindGameObjectWithTag("Quad").GetComponent<MediaScript>().Pause();
        }
        if (Input.GetKey(resumeButton))
        {
           // Resume_Script.ResumeGame();
        }
    }
    
}
