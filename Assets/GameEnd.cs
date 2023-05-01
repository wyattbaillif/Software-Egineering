using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class GameEnd : MonoBehaviour
{

    public GameObject winnerText;

    public bool player1Dead=false;
    public bool player2Dead=false;
    public bool player3Dead=false;
    public bool player4Dead=false;

    private string player1Time;
    private string player2Time;
    private string player3Time;
    private string player4Time;
    public bool gameEnded=false;
    

    public int deathCount=0;

    TextMeshProUGUI Winner_text;
    List<Tuple<string, float>> scores = new List<Tuple<string, float>>();


    private void printScores()
    {
        scores.Add(Tuple.Create("player 1", float.Parse(player1Time)));
        scores.Add(Tuple.Create("player 2", float.Parse(player2Time)));
        scores.Add(Tuple.Create("player 3", float.Parse(player3Time)));
        scores.Add(Tuple.Create("player 4", float.Parse(player4Time)));
        
        
        var sortedScores = scores.OrderByDescending(x => x.Item2).ToList();

        string formattedScores="";
        int i=0;
        foreach(var tuple in sortedScores)
        {
            if(i==0)
            {
                formattedScores+=string.Format("Winner: {0}\nScore: {1:F2}\n\n\n\n\n",tuple.Item1,tuple.Item2);
                i+=1;
            }
            else
            {
                formattedScores += string.Format("{0}: {1:F2}\n", tuple.Item1, tuple.Item2);
            }
            
        }
        
        
        Winner_text.enabled=true;
        Winner_text.text=(formattedScores);
    }
    private void Finish()
    {
        
        
        
        if(player1Dead==false)
        {
            player1Time=(GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime+5.0f).ToString();
            GameObject.Find("player1").GetComponent<MovementTest>().enabled=false;
        }
        if(player2Dead==false)
        {
            player2Time=(GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime+5.0f).ToString();
            GameObject.Find("player2").GetComponent<MovementTest>().enabled=false;
        }
        if(player3Dead==false)
        {
            player3Time=(GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime+5.0f).ToString();
            GameObject.Find("player3").GetComponent<MovementTest>().enabled=false;
        }
        if(player4Dead==false)
        {
            player4Time=(GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime+5.0f).ToString();
            GameObject.Find("player4").GetComponent<MovementTest>().enabled=false;
        }
        printScores();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Winner_text = winnerText.GetComponent<TextMeshProUGUI>();
        Winner_text.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("player1").GetComponent<elimination>().playerDead==true)
        {
            player1Dead=true;
            GameObject.Find("player1").GetComponent<elimination>().playerDead=false;
            player1Time=GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime.ToString();
            deathCount+=1;
        }
        if(GameObject.Find("player2").GetComponent<elimination>().playerDead==true)
        {
            player2Dead=true;
            GameObject.Find("player2").GetComponent<elimination>().playerDead=false;
            player2Time=GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime.ToString();
            deathCount+=1;
        }
        if(GameObject.Find("player3").GetComponent<elimination>().playerDead==true)
        {
            player3Dead=true;
            GameObject.Find("player3").GetComponent<elimination>().playerDead=false;
            player3Time=GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime.ToString();
            deathCount+=1;
        }
        if(GameObject.Find("player4").GetComponent<elimination>().playerDead==true)
        {
            player4Dead=true;
            GameObject.Find("player4").GetComponent<elimination>().playerDead=false;
            player4Time=GameObject.Find("Canvas").GetComponent<TimerContoller>().currentTime.ToString();
            deathCount+=1;
        }
        if(deathCount==3)
        {
            gameEnded=true;
            Destroy(GameObject.Find("Boss"));
            Destroy(GameObject.FindWithTag("Projectile"));
            deathCount=0;
            Finish();
        }
    }
}
