using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerContoller : MonoBehaviour
{

    public GameObject Timer; //TextMesh for displaying the timer
    public float StartTime; //The time at which the timer starts
    public float currentTime; //The current time


    public bool EndStatus=false;

    

    TextMeshProUGUI Timer_text;

    void Start()
    {
        Timer_text = Timer.GetComponent<TextMeshProUGUI>();
        currentTime = StartTime; //Set the current time to the start time
    }


    void Update()
    {
        if(!GameObject.Find("Canvas").GetComponent<GameEnd>().gameEnded)
        {
            currentTime += Time.deltaTime; //Increase the current time by the time since the last frame
            Timer_text.text = currentTime.ToString("F2"); //Format and display the current time in the TextMesh
        }
        
    }
}
