using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using Unity.Netcode;

public class GameEnd : NetworkBehaviour
{

    public GameObject winnerText;

    public string player1Name;
    public string player2Name;
    public string player3Name;
    public string player4Name;
    public bool player1Dead;
    public bool player2Dead;
    public bool player3Dead;
    public bool player4Dead;
    private string player1Time;
    private string player2Time;
    private string player3Time;
    private string player4Time;
    public bool gameEnded=false;

    private int numPlayers=0;
    

    public int deathCount=0;

    TextMeshProUGUI Winner_text;

    List<GameObject> players1 = new List<GameObject>();
    List<Tuple<string, float>> scores = new List<Tuple<string, float>>();


    private void printScores()
    {
        scores.Add(Tuple.Create(player1Name, float.Parse(player1Time)));
        scores.Add(Tuple.Create(player2Name, float.Parse(player2Time)));
        scores.Add(Tuple.Create(player3Name, float.Parse(player3Time)));
        scores.Add(Tuple.Create(player4Name, float.Parse(player4Time)));
        
        
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
        if(!player1Dead){
            player1Time=elimination.Instance.Time+5f.ToString();
            player1Name=elimination.Instance.User;
        }
        if(!player2Dead){
            player2Time=elimination.Instance.Time+5f.ToString();
            player2Name=elimination.Instance.User;
        }
        if(!player3Dead){
            player3Time=elimination.Instance.Time+5f.ToString();
            player3Name=elimination.Instance.User;
        }
        if(!player4Dead){
            player4Time=elimination.Instance.Time+5f.ToString();
            player4Name=elimination.Instance.User;
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
        if(deathCount!=-1){
            if(elimination.Instance.Id==0 && elimination.Instance.playerDead){
                deathCount+=1;
                player1Time=elimination.Instance.Time.ToString();
                player1Name=elimination.Instance.User;
                player1Dead=true;
            }
            if(elimination.Instance.Id==1 && elimination.Instance.playerDead){
                deathCount+=1;
                player2Time=elimination.Instance.Time.ToString();
                player2Name=elimination.Instance.User;
                player2Dead=true;
            }
            if(elimination.Instance.Id==2 && elimination.Instance.playerDead){
                deathCount+=1;
                player3Time=elimination.Instance.Time.ToString();
                player3Name=elimination.Instance.User;
                player3Dead=true;
            }
            if(elimination.Instance.Id==3 && elimination.Instance.playerDead){
                deathCount+=1;
                player4Time=elimination.Instance.Time.ToString();
                player4Name=elimination.Instance.User;
                player4Dead=true;
            }
            if(deathCount==3)
                {
                gameEnded=true;
                Destroy(GameObject.Find("Boss"));
                Destroy(GameObject.Find("Projectile"));
                deathCount=-1;
                Finish();
                }
        }
    }
}
